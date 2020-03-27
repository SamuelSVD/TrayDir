object MainForm: TMainForm
  Left = 0
  Top = 0
  BorderStyle = bsSingle
  Caption = 'TrayDir'
  ClientHeight = 117
  ClientWidth = 555
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  Menu = MainMenu1
  OldCreateOrder = False
  OnCreate = FormCreate
  OnResize = FormResize
  PixelsPerInch = 96
  TextHeight = 13
  object GroupBox1: TGroupBox
    Left = 9
    Top = 8
    Width = 538
    Height = 97
    Caption = 'Directory'
    TabOrder = 0
    object DirEdit: TEdit
      Left = 24
      Top = 24
      Width = 417
      Height = 21
      ReadOnly = True
      TabOrder = 0
    end
    object Button1: TButton
      Left = 447
      Top = 22
      Width = 75
      Height = 25
      Action = BrowseAction
      TabOrder = 1
    end
    object ShortcutsAsAdminCheckBox: TCheckBox
      Left = 24
      Top = 64
      Width = 498
      Height = 17
      Action = ShortcutsAsAdminAction
      Alignment = taLeftJustify
      TabOrder = 2
      Visible = False
    end
    object FilesAsAdminCheckBox: TCheckBox
      Left = 24
      Top = 64
      Width = 498
      Height = 17
      Action = FilesAsAdminAction
      Alignment = taLeftJustify
      TabOrder = 3
    end
  end
  object TrayIcon: TTrayIcon
    PopupMenu = PopupMenu
    Visible = True
    OnDblClick = TrayIconDblClick
    Left = 176
    Top = 16
  end
  object ActionList1: TActionList
    Left = 264
    Top = 32
    object HideAction: TAction
      Caption = 'Hide'
      OnExecute = HideActionExecute
    end
    object ShowAction: TAction
      Caption = 'Show'
      OnExecute = ShowActionExecute
    end
    object ExitAction: TAction
      Caption = 'Exit'
      OnExecute = ExitActionExecute
    end
    object BrowseAction: TAction
      Caption = 'Browse'
      OnExecute = BrowseActionExecute
    end
    object RunAction: TAction
    end
    object AboutAction: TAction
      Caption = 'About'
      OnExecute = AboutActionExecute
    end
    object ExploreAction: TAction
      Caption = 'Explore'
      OnExecute = ExploreActionExecute
    end
    object ShortcutsAsAdminAction: TAction
      Caption = 'Run Shortcuts As Admin'
      OnExecute = ShortcutsAsAdminActionExecute
    end
    object FilesAsAdminAction: TAction
      Caption = 'Run Files As Admin'
      OnExecute = FilesAsAdminActionExecute
    end
  end
  object PopupMenuTemplate: TPopupMenu
    MenuAnimation = [maLeftToRight]
    Left = 336
    Top = 16
    object Item21: TMenuItem
      Action = ShowAction
    end
    object Item11: TMenuItem
      Action = HideAction
    end
    object N2: TMenuItem
      Caption = '-'
    end
    object N1: TMenuItem
      Caption = '-'
    end
    object Item31: TMenuItem
      Action = ExitAction
    end
  end
  object Timer1: TTimer
    Interval = 50
    OnTimer = Timer1Timer
    Left = 56
    Top = 16
  end
  object OpenDialog: TFileOpenDialog
    FavoriteLinks = <>
    FileTypes = <>
    Options = [fdoPickFolders]
    Left = 120
    Top = 16
  end
  object PopupMenu: TPopupMenu
    Left = 392
    Top = 24
  end
  object MainMenu1: TMainMenu
    Left = 224
    Top = 24
    object Exit1: TMenuItem
      Action = ExitAction
    end
    object Explore1: TMenuItem
      Action = ExploreAction
    end
    object Browse1: TMenuItem
      Action = BrowseAction
    end
    object Action11: TMenuItem
      Action = AboutAction
    end
  end
end
