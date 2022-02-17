using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Serialization;


namespace TrayDir
{
    [XmlRoot(ElementName = "Instance")]
    public class TrayInstance
    {
        [XmlElement(ElementName = "Settings")]
        public TrayInstanceSettings settings;
        [XmlAttribute]
        public string iconPath;
        [XmlAttribute]
        public string instanceName;
        [XmlAttribute]
        public string ignoreRegex = "";
        [XmlAttribute]
        public string Version = Assembly.GetEntryAssembly().GetName().Version.ToString();
        [XmlIgnore]
        public IView view;
        public List<TrayInstancePath> paths;
        public List<TrayInstanceVirtualFolder> vfolders;
        public List<TrayInstancePlugin> plugins;
        public List<TrayPlugin> internalPlugins;
        public TrayInstanceNode nodes;

        public byte[] iconData;
        public static string defaultPath = "";
        public int PathCount { get { return paths.Count; } }
        public int NodeCount { get { int i = 0; i += nodes.NodeCount - 1; return i; } }
        public string[] regexList { get { return ignoreRegex.Split('\r', '\n'); } }
        public TrayInstance() : this("New Instance") { }
        public TrayInstance(string instanceName) : this(instanceName, new TrayInstanceSettings())
        {
        }
        public TrayInstance(String instanceName, TrayInstanceSettings settings)
        {
            this.settings = settings;
            this.instanceName = instanceName;
            paths = new List<TrayInstancePath>();
            vfolders = new List<TrayInstanceVirtualFolder>();
            plugins = new List<TrayInstancePlugin>();
            nodes = new TrayInstanceNode();
        }
        public void Repair()
        {
            // Separate nodes into their types
            List<TrayInstanceNode> pathNodes = new List<TrayInstanceNode>();
            List<TrayInstanceNode> vfolderNodes = new List<TrayInstanceNode>();
            List<TrayInstanceNode> pluginNodes = new List<TrayInstanceNode>();
            foreach (TrayInstanceNode node in nodes.GetAllChildNodes())
            {
                switch(node.type)
                {
                    case TrayInstanceNode.NodeType.Path:
                        pathNodes.Add(node);
                        break;
                    case TrayInstanceNode.NodeType.Plugin:
                        pluginNodes.Add(node);
                        break;
                    case TrayInstanceNode.NodeType.VirtualFolder:
                        vfolderNodes.Add(node);
                        break;
                }
            }
            // Link nodes to their corresponding data
            foreach (TrayInstanceNode node in pathNodes)
            {
                node.__path = paths[node.id];
            }
            foreach (TrayInstanceNode node in vfolderNodes)
            {
                node.__vfolder = vfolders[node.id];
            }
            foreach (TrayInstanceNode node in pluginNodes)
            {
                node.__plugin = plugins[node.id];
            }

            // Detect and remove paths that are not used
            List<TrayInstancePath> deletablePaths = new List<TrayInstancePath>();
            foreach (TrayInstancePath path in paths)
            {
                bool found = false;
                foreach (TrayInstanceNode node in pathNodes)
                {
                    if (node.__path == path)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    deletablePaths.Add(path);
                }
            }
            foreach (TrayInstancePath path in deletablePaths)
            {
                paths.Remove(path);
            }

            // Detect and remove paths that are not used
            List<TrayInstancePlugin> deletablePlugins = new List<TrayInstancePlugin>();
            foreach (TrayInstancePlugin plugin in plugins)
            {
                bool found = false;
                foreach (TrayInstanceNode node in pluginNodes)
                {
                    if (node.__plugin == plugin)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    deletablePlugins.Add(plugin);
                }
            }
            foreach (TrayInstancePlugin plugin in deletablePlugins)
            {
                plugins.Remove(plugin);
            }

            // Detect and remove paths that are not used
            List<TrayInstanceVirtualFolder> deletableVfoldersPaths = new List<TrayInstanceVirtualFolder>();
            foreach (TrayInstanceVirtualFolder vfolder in vfolders)
            {
                bool found = false;
                foreach (TrayInstanceNode node in vfolderNodes)
                {
                    if (node.__vfolder == vfolder)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    deletableVfoldersPaths.Add(vfolder);
                }
            }
            foreach (TrayInstanceVirtualFolder path in deletableVfoldersPaths)
            {
                vfolders.Remove(path);
            }

            // Fix all IDs
            foreach (TrayInstanceNode node in pathNodes)
            {
                node.id = paths.IndexOf(node.__path);
            }
            foreach (TrayInstanceNode node in pluginNodes)
            {
                node.id = plugins.IndexOf(node.__plugin);
            }
            foreach (TrayInstanceNode node in vfolderNodes)
            {
                node.id = vfolders.IndexOf(node.__vfolder);
            }
        }
        public TrayPlugin getGlobalPluginBySignature(string signature)
        {
            if (ProgramData.pd.plugins != null)
            {
                foreach (TrayPlugin tp in ProgramData.pd.plugins)
                {
                    if (tp.getSignature() == signature) return tp;
                }
            }
            return null;
        }
        public TrayPlugin getInternalPluginBySignature(string signature)
        {
            if (internalPlugins != null)
            {
                foreach (TrayPlugin tp in internalPlugins)
                {
                    if (tp.getSignature() == signature) return tp;
                }
            }
            return null;
        }
        private void recursiveRereferencePlugins(TrayInstanceNode tin)
        {
            if (tin.type == TrayInstanceNode.NodeType.Plugin)
            {
                if (internalPlugins == null)
                {
                    internalPlugins = new List<TrayPlugin>();
                }
                TrayInstancePlugin ip = plugins[tin.id];
                if (ip.plugin != null)
                {
                    TrayPlugin tp = getInternalPluginBySignature(ip.plugin.getSignature());
                    if (tp == null)
                    {
                        internalPlugins.Add(ip.plugin);
                        tp = ip.plugin;
                    }
                    ip.id = internalPlugins.IndexOf(tp);
                }
            }
            foreach (TrayInstanceNode tinChild in tin.children)
            {
                recursiveRereferencePlugins(tinChild);
            }
        }
        public void buildAndReferenceInternalPlugin()
        {
            recursiveRereferencePlugins(nodes);
        }
        public void loadGlobalFromInternalPluginAndRereference()
        {
            if(internalPlugins != null)
            {
                foreach(TrayPlugin plugin in internalPlugins)
                {
                    TrayPlugin gtp = getGlobalPluginBySignature(plugin.getSignature());
                    if (gtp == null)
                    {
                        ProgramData.pd.plugins.Add(plugin);
                        gtp = plugin;
                    }
                }
                foreach (TrayInstancePlugin tip in plugins)
                {
                    if (tip.id < internalPlugins.Count && tip.id >= 0)
                    {
                        int newID = ProgramData.pd.plugins.IndexOf(getGlobalPluginBySignature(internalPlugins[tip.id].getSignature()));
                        tip.id = newID;
                    }
                }
            }
        }
        public void FixPaths()
        {
            if (settings.paths != null) {
                if (settings.paths.Count > 0) {
                    foreach (string path in settings.paths) {
                        paths.Add(new TrayInstancePath(path));
                    }
                }
            }
            settings.paths = null;
        }
        public void FixNodes()
        {
            if (PathCount + plugins.Count != NodeCount) {
                nodes.children.Clear();
                foreach (TrayInstancePath tip in paths) {
                    TrayInstanceNode tin = new TrayInstanceNode();
                    tin.id = paths.IndexOf(tip);
                    tin.type = TrayInstanceNode.NodeType.Path;
                    nodes.children.Add(tin);
                    tin.parent = nodes;
                }
                foreach (TrayInstancePlugin tip in plugins) {
                    TrayInstanceNode tin = new TrayInstanceNode();
                    tin.id = plugins.IndexOf(tip);
                    tin.type = TrayInstanceNode.NodeType.Plugin;
                    nodes.children.Add(tin);
                    tin.parent = nodes;
                }
            }
            nodes.SetInstance(this);
            nodes.FixChildren();
        }
        public TrayInstance Copy()
        {
            TrayInstance ti = new TrayInstance();
            ti.settings = settings.Copy();
            ti.iconPath = iconPath;
            ti.instanceName = instanceName;
            ti.ignoreRegex = ignoreRegex;
            ti.iconData = iconData;
            foreach (TrayInstancePath tip in paths)
            {
                ti.paths.Add(tip.Copy());
            }
            foreach(TrayInstanceVirtualFolder tivf in vfolders)
            {
                ti.vfolders.Add(tivf.Copy());
            }
            foreach(TrayInstancePlugin tip in plugins)
            {
                ti.plugins.Add(tip.Copy());
            }
            ti.nodes = nodes.Copy();
            return ti;
        }
    }
}
