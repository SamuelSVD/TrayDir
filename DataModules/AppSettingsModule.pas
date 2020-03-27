unit AppSettingsModule;

interface

uses
  System.SysUtils, System.Classes, System.IniFiles;

type
  TAppSettings = class(TDataModule)
  private
    { Private declarations }
    f:textfile;
    iniFile: TIniFile;
  public
    { Public declarations }
    sDirPath: String;
    sIniPath: String;
    sProgramPath: String;
    sTrayIconFilePath: String;
    bRunShortcutsAsAdmin: boolean;
    bRunFilesAsAdmin: boolean;
    DirList: TStringList;
    procedure Initialize;
    procedure LoadSettings;
    procedure WriteSettings;
    procedure SetDirPath(sPath: String);
    procedure LoadDirList(sPath: String);
    function GetDirList(sPath: String): TStringList;
  end;

var
  AppSettings: TAppSettings;

implementation

{%CLASSGROUP 'Vcl.Controls.TControl'}

{$R *.dfm}

procedure TAppSettings.Initialize;
begin
  sProgramPath := ExtractFilePath(ParamStr(0));
  sIniPath := sProgramPath+'options.ini';
  IniFile := TIniFile.Create(sIniPath);
  DirList:=TStringList.Create;
  LoadSettings;
end;

procedure TAppSettings.LoadSettings;
begin
  sDirPath := IniFile.ReadString('Program','DirPath','');
  bRunShortcutsAsAdmin:=IniFile.ReadBool('Program', 'RunShortcutsAsAdmin',False);
  bRunFilesAsAdmin:=IniFile.ReadBool('Program', 'RunFilesAsAdmin', True);
  sTrayIconFilePath:=IniFile.ReadString('Program','TrayIconPath','TrayIcon.ico');
  WriteSettings;
end;

procedure TAppSettings.WriteSettings;
begin
  IniFile.WriteString('Program', 'DirPath', sDirPath);
  IniFile.WriteBool('Program', 'RunShortcutsAsAdmin',bRunShortcutsAsAdmin);
  IniFile.WriteBool('Program', 'RunFilesAsAdmin', bRunFilesAsAdmin);
  IniFile.WriteString('Program','TrayIconPath',sTrayIconFilePath);
end;

procedure TAppSettings.SetDirPath(sPath: String);
begin
  AssignFile(f,sIniPath);
  Rewrite(f);
  WriteLn(f,sPath);
  CloseFile(f);
  sDirPath:=sPath;
  LoadDirList(sPath);
end;

procedure TAppSettings.LoadDirList(sPath: String);
begin
  DirList.Clear;
  DirList:=GetDirList(sDirPath);
end;

function TAppSettings.GetDirList(sPath: String): TStringList;
var
  StringList: TStringList;
  SR: TSearchRec;
begin
  StringList := TStringList.Create;
  if (sPath <> '') then begin
    if FindFirst(sPath+'\*', faAnyFile, SR) = 0 then begin
      repeat
        if (SR.Name[1] <> '.') then begin
          StringList.Add(SR.Name);
        end;
      until FindNext(SR) <> 0;
      FindClose(SR);
    end;
  end;
  Result:=StringList;
end;
end.
