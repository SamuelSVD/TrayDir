program TrayDir;

uses
  Vcl.Forms,
  MainFormUnit in 'Forms\MainFormUnit.pas' {MainForm},
  AboutFormUnit in 'Forms\AboutFormUnit.pas' {AboutForm},
  AppSettingsModule in 'DataModules\AppSettingsModule.pas' {AppSettings: TDataModule};

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TAppSettings, AppSettings);
  AppSettings.Initialize;
  if AppSettings.sDirPath <> '' then begin
    Application.ShowMainForm:=False;
  end;
  Application.CreateForm(TMainForm, MainForm);
  Application.CreateForm(TAboutForm, AboutForm);
  Application.Run;
end.
