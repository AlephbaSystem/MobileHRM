using Android.Graphics;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using MobileHRM.Controls;
using MobileHRM.Droid.Extensions;
using Xamarin.Forms.Platform.Android;

namespace MobileHRM.Droid.Controls
{
    public class CustomShellItemRenderer : ShellItemRenderer
    {
        FrameLayout _shellOverlay;
        BottomNavigationView _bottomView;

        public CustomShellItemRenderer(IShellContext shellContext) : base(shellContext)
        {
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View outerlayout = base.OnCreateView(inflater, container, savedInstanceState);
            _bottomView = outerlayout.FindViewById<BottomNavigationView>(Resource.Id.bottomtab_tabbar);
            _shellOverlay = outerlayout.FindViewById<FrameLayout>(Resource.Id.bottomtab_tabbar_container);

            if (ShellItem is CustomTabbar todoTabBar && todoTabBar.LargeTab != null)
            {
                SetupLargeTab();
            }

            return outerlayout;
        }

        private async void SetupLargeTab()
        {
            CustomTabbar todoTabBar = (CustomTabbar)ShellItem;
            FrameLayout layout = new FrameLayout(Context);

            IImageSourceHandler imageHandler = todoTabBar.LargeTab.Icon.GetHandler();
            Bitmap bitmap = await imageHandler.LoadImageAsync(todoTabBar.LargeTab.Icon, Context);
            ImageView image = new ImageView(Context);
            image.SetImageBitmap(bitmap);

            layout.AddView(image);

            FrameLayout.LayoutParams lp = new FrameLayout.LayoutParams(300, 300);
            _bottomView.Measure((int)MeasureSpecMode.Unspecified, (int)MeasureSpecMode.Unspecified);
            lp.BottomMargin = _bottomView.MeasuredHeight / 2;

            layout.LayoutParameters = lp;

            _shellOverlay.RemoveAllViews();
            _shellOverlay.AddView(layout);
        }
    }
}