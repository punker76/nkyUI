using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Styling;
using nkyUI.Controls.Dialogs;
using nkyUI.Util;
using System;

namespace nkyUI.Controls
{
    public class KYUIWindow : Window, IStyleable
    {
        public static readonly AvaloniaProperty<Control> WindowCommandsProperty =
            AvaloniaProperty.Register<KYUIWindow, Control>(nameof(WindowCommands));

        public static readonly AvaloniaProperty<Image> IconImageProperty =
            AvaloniaProperty.Register<KYUIWindow, Image>(nameof(IconImage));

        private Grid bottomHorizontalGrip;
        private Grid bottomLeftGrip;
        private Grid bottomRightGrip;
        private Button closeButton;
        private Panel iconPanel;
        private Image iconImage;
        private Grid leftVerticalGrip;
        private Button minimizeButton;
        internal Grid overlayBox; //The overlay that is shown when ShowOverlay is called
        public OverlayDialog DialogHost { get; private set; }

        private bool mouseDown;
        private Point mouseDownPosition;
        private Button restoreButton;
        private Grid rightVerticalGrip;

        private Grid titleBar;
        private Grid topHorizontalGrip;
        private Grid topLeftGrip;
        private Grid topRightGrip;

        public Control WindowCommands
        {
            get { return GetValue(WindowCommandsProperty); }
            set { SetValue(WindowCommandsProperty, value); }
        }

        public Image IconImage
        {
            get { return GetValue(IconImageProperty); }
            set { SetValue(IconImageProperty, value); }
        }

        Type IStyleable.StyleKey => typeof(KYUIWindow);

        protected override void OnPointerPressed(PointerPressedEventArgs e)
        {
            if (topHorizontalGrip.IsPointerOver)
            {
                BeginResizeDrag(WindowEdge.North);
            }
            else if (bottomHorizontalGrip.IsPointerOver)
            {
                BeginResizeDrag(WindowEdge.South);
            }
            else if (leftVerticalGrip.IsPointerOver)
            {
                BeginResizeDrag(WindowEdge.West);
            }
            else if (rightVerticalGrip.IsPointerOver)
            {
                BeginResizeDrag(WindowEdge.East);
            }
            else if (topLeftGrip.IsPointerOver)
            {
                BeginResizeDrag(WindowEdge.NorthWest);
            }
            else if (bottomLeftGrip.IsPointerOver)
            {
                BeginResizeDrag(WindowEdge.SouthWest);
            }
            else if (topRightGrip.IsPointerOver)
            {
                BeginResizeDrag(WindowEdge.NorthEast);
            }
            else if (bottomRightGrip.IsPointerOver)
            {
                BeginResizeDrag(WindowEdge.SouthEast);
            }
            else if (titleBar.IsPointerOver)
            {
                mouseDown = true;
                mouseDownPosition = e.GetPosition(this);
            }
            else
            {
                mouseDown = false;
            }

            base.OnPointerPressed(e);
        }

        protected override void OnPointerReleased(PointerEventArgs e)
        {
            mouseDown = false;
            base.OnPointerReleased(e);
        }

        protected override void OnPointerMoved(PointerEventArgs e)
        {
            if (titleBar.IsPointerOver && mouseDown)
            {
                if (mouseDownPosition.DistanceTo(e.GetPosition(this)) > 12)
                {
                    WindowState = WindowState.Normal;
                    BeginMoveDrag();
                    mouseDown = false;
                }
            }

            base.OnPointerMoved(e);
        }

        private void ToggleWindowState()
        {
            switch (WindowState)
            {
                case WindowState.Maximized:
                    WindowState = WindowState.Normal;
                    //Restore to normal size
                    PseudoClasses.Remove(":maximized");
                    break;

                case WindowState.Normal:
                    WindowState = WindowState.Maximized;
                    //Maximize the window
                    PseudoClasses.Add(":maximized");
                    break;
            }
        }

        protected override void OnTemplateApplied(TemplateAppliedEventArgs e)
        {
            titleBar = e.NameScope.Find<Grid>("titlebar");
            minimizeButton = e.NameScope.Find<Button>("minimizeButton");
            restoreButton = e.NameScope.Find<Button>("restoreButton");
            closeButton = e.NameScope.Find<Button>("closeButton");
            iconPanel = e.NameScope.Find<Panel>("iconPanel");
            iconImage = e.NameScope.Find<Image>("iconImage");
            overlayBox = e.NameScope.Find<Grid>("overlayBox");

            DialogHost = new OverlayDialog
            {
                DialogContainer = e.NameScope.Find<Grid>("overlayDialogContainer"),
                DialogTitleBlock = e.NameScope.Find<TextBlock>("overlayDialogTitle"),
                DialogTextBlock = e.NameScope.Find<TextBlock>("overlayDialogText"),
            };

            topHorizontalGrip = e.NameScope.Find<Grid>("topHorizontalGrip");
            bottomHorizontalGrip = e.NameScope.Find<Grid>("bottomHorizontalGrip");
            leftVerticalGrip = e.NameScope.Find<Grid>("leftVerticalGrip");
            rightVerticalGrip = e.NameScope.Find<Grid>("rightVerticalGrip");

            topLeftGrip = e.NameScope.Find<Grid>("topLeftGrip");
            bottomLeftGrip = e.NameScope.Find<Grid>("bottomLeftGrip");
            topRightGrip = e.NameScope.Find<Grid>("topRightGrip");
            bottomRightGrip = e.NameScope.Find<Grid>("bottomRightGrip");

            minimizeButton.Click += (sender, ee) => { WindowState = WindowState.Minimized; };

            restoreButton.Click += (sender, ee) => { ToggleWindowState(); };

            titleBar.DoubleTapped += (sender, ee) => { ToggleWindowState(); };

            closeButton.Click += (sender, ee) => { Application.Current.Exit(); };

            iconPanel.DoubleTapped += (sender, ee) => { Close(); };
        }

        public void ShowOverlay()
        {
            overlayBox.Opacity = 1;
            overlayBox.ZIndex = 2;
        }

        public void HideOverlay()
        {
            overlayBox.Opacity = 0;
            overlayBox.ZIndex = -1;
        }
    }
}