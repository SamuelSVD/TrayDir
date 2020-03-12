unit AppSettingsModule;

interface

uses
  System.SysUtils, System.Classes;

type
  TAppSettings = class(TDataModule)
  private
    { Private declarations }
    f:textfile;
  public
    { Public declarations }
    sDirPath: String;
    sConfigPath: String;
    sProgramPath: String;
    DirList: TStringList;
    procedure Initialize;
    procedure SetDirPath(sPath: String);
    procedure LoadDirList;
  end;

var
  AppSettings: TAppSettings;

implementation

{%CLASSGROUP 'Vcl.Controls.TControl'}

{$R *.dfm}

procedure TAppSettings.Initialize;
begin
  sProgramPath := ExtractFilePath(ParamStr(0));
  sConfigPath := sProgramPath+'options.ini';
  DirList:=TStringList.Create;
  if FileExists(sConfigPath) then begin
    AssignFile(f,sConfigPath);
    Reset(f);
    ReadLn(f,sDirPath);
    CloseFile(f);
  end else begin
    AssignFile(f,sConfigPath);
    Rewrite(f);
    WriteLn(f,'');
    CloseFile(f);
    sDirPath:='';
  end;
end;

procedure TAppSettings.SetDirPath(sPath: String);
begin
  AssignFile(f,sConfigPath);
  Rewrite(f);
  WriteLn(f,sPath);
  CloseFile(f);
  sDirPath:=sPath;
  LoadDirList;
end;

procedure TAppSettings.LoadDirList;
var
  SR: TSearchRec;
begin
  DirList.Clear;
  if (sDirPath <> '') then begin
    if FindFirst(sDirPath+'\*', faAnyFile, SR) = 0 then begin
      repeat
        if (SR.Name[1] <> '.') then begin
          DirList.Add(SR.Name);
        end;
      until FindNext(SR) <> 0;
      FindClose(SR);
    end;
  end;
end;

end.
