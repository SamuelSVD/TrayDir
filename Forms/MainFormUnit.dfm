object MainForm: TMainForm
  Left = 0
  Top = 0
  BorderStyle = bsSingle
  Caption = 'TrayDir'
  ClientHeight = 81
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
    Left = 8
    Top = 4
    Width = 538
    Height = 65
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
      OnExecute = RunActionExecute
    end
    object AboutAction: TAction
      Caption = 'About'
      OnExecute = AboutActionExecute
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
    object Browse1: TMenuItem
      Action = BrowseAction
    end
    object Action11: TMenuItem
      Action = AboutAction
    end
  end
end
