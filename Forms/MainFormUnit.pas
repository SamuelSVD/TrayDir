unit MainFormUnit;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.ExtCtrls, System.Actions,
  Vcl.ActnList, Vcl.Menus, Vcl.StdCtrls, ShellAPI;

type
  TMainForm = class(TForm)
    TrayIcon: TTrayIcon;
    ActionList1: TActionList;
    PopupMenuTemplate: TPopupMenu;
    Item11: TMenuItem;
    Item21: TMenuItem;
    Item31: TMenuItem;
    HideAction: TAction;
    ShowAction: TAction;
    ExitAction: TAction;
    N1: TMenuItem;
    N2: TMenuItem;
    Timer1: TTimer;
    DirEdit: TEdit;
    Button1: TButton;
    BrowseAction: TAction;
    OpenDialog: TFileOpenDialog;
    GroupBox1: TGroupBox;
    PopupMenu: TPopupMenu;
    RunAction: TAction;
    MainMenu1: TMainMenu;
    AboutAction: TAction;
    Action11: TMenuItem;
    Exit1: TMenuItem;
    Browse1: TMenuItem;
    procedure HideActionExecute(Sender: TObject);
    procedure ShowActionExecute(Sender: TObject);
    procedure TrayIconDblClick(Sender: TObject);
    procedure ExitActionExecute(Sender: TObject);
    procedure FormResize(Sender: TObject);
    procedure Timer1Timer(Sender: TObject);
    procedure BrowseActionExecute(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure RunActionExecute(Sender: TObject);
    procedure AboutActionExecute(Sender: TObject);
  private
    { Private declarations }
    procedure CreatePopupMenu;
  public
    { Public declarations }
  end;

var
  MainForm: TMainForm;

implementation

{$R *.dfm}

uses AboutFormUnit, AppSettingsModule;

procedure TMainForm.CreatePopupMenu;
var
  MenuItem: TMenuItem;
  i: integer;
begin
  PopupMenu.Items.Clear;
  MenuItem:=TMenuItem.Create(self);
  MenuItem.Action :=  PopupMenuTemplate.Items[0].Action;
  PopupMenu.Items.Add(MenuItem);
  MenuItem:=TMenuItem.Create(self);
  MenuItem.Action :=  PopupMenuTemplate.Items[1].Action;
  PopupMenu.Items.Add(MenuItem);
  MenuItem:=TMenuItem.Create(self);
  MenuItem.Caption:='-';
  PopupMenu.Items.Add(MenuItem);
  for i := 0 to AppSettings.DirList.Count - 1 do
  begin
    MenuItem:=TMenuItem.Create(self);
    MenuItem.Caption:=AppSettings.DirList[i];
    MenuItem.onClick:=RunActionExecute;
    PopupMenu.Items.Add(MenuItem);
  end;
  MenuItem:=TMenuItem.Create(self);
  MenuItem.Caption:='-';
  PopupMenu.Items.Add(MenuItem);
  MenuItem:=TMenuItem.Create(self);
  MenuItem.Action :=  PopupMenuTemplate.Items[4].Action;
  PopupMenu.Items.Add(MenuItem);
end;

procedure TMainForm.HideActionExecute(Sender: TObject);
begin
  Application.Minimize;
  Timer1.Enabled:=True;
end;

procedure TMainForm.ShowActionExecute(Sender: TObject);
begin
  WindowState := wsNormal;
  Application.BringToFront();
  Timer1.Enabled:=True;
end;

procedure TMainForm.RunActionExecute(Sender: TObject);
var
  filename: string;
begin
  filename:=AppSettings.sDirPath+'\'+TMenuItem(Sender).Caption;
  filename:=StringReplace(filename,'&','',[]);
  ShellExecute(Handle, 'runas', PWideChar(filename), nil, nil, SW_SHOWNORMAL);
end;

procedure TMainForm.AboutActionExecute(Sender: TObject);
begin
  AboutForm.Show;
end;

procedure TMainForm.BrowseActionExecute(Sender: TObject);
begin
  if(OpenDialog.Execute()) then begin
    AppSettings.SetDirPath(OpenDialog.FileName);
    DirEdit.Text:=AppSettings.sDirPath;
    CreatePopupMenu;
  end;
end;

procedure TMainForm.ExitActionExecute(Sender: TObject);
begin
  MainForm.Close;
end;

procedure TMainForm.FormCreate(Sender: TObject);
var
  MyIcon: TIcon;
begin
  DirEdit.Text:=AppSettings.sDirPath;
  AppSettings.LoadDirList;
  CreatePopupMenu;
  if Application.ShowMainForm = False then begin
    MainForm.WindowState := wsMinimized;
  end;

  if FileExists(AppSettings.sProgramPath+'tray.ico') then begin
    TrayIcon.Icons := TImageList.Create(Self);
    MyIcon := TIcon.Create;
    MyIcon.LoadFromFile(AppSettings.sProgramPath+'tray.ico');
    TrayIcon.Icon.Assign(MyIcon);
    TrayIcon.Visible := True;
    TrayIcon.Animate := True;
    TrayIcon.ShowBalloonHint;
  end;
end;

procedure TMainForm.FormResize(Sender: TObject);
begin
  if MainForm.WindowState = wsMinimized then begin
    HideAction.Execute;
  end;
  Timer1.Enabled:=True;
end;

procedure TMainForm.Timer1Timer(Sender: TObject);
begin
  if MainForm.WindowState = wsMinimized then begin
    HideAction.Visible:=False;
    ShowAction.Visible:=True;
    MainForm.Visible:=False;
  end else begin
    ShowAction.Visible:=False;
    HideAction.Visible:=True;
    MainForm.Visible:=True;
  end;
  Timer1.Enabled:=False;
end;

procedure TMainForm.TrayIconDblClick(Sender: TObject);
begin
  ShowAction.Execute;
end;

end.
