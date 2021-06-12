using System;
using System.Collections.Generic;
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
        [XmlIgnore]
        public IView view;
        public List<TrayInstancePath> paths;
        public List<TrayInstanceVirtualFolder> vfolders;
        public List<TrayInstancePlugin> plugins;
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
            foreach (TrayInstanceNode node in pluginNodes)
            {
                node.__plugin = plugins[node.id];
            }
            foreach (TrayInstanceNode node in vfolderNodes)
            {
                node.__vfolder = vfolders[node.id];
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
    }
}
