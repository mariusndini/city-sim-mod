using UnityEngine;
using ICities;
using ColossalFramework;
using ColossalFramework.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


 
namespace data
{
    class userUI
    {
        UIPanel infoPanel;
        Vector2 size = new Vector2(250, 700);

        public userUI()
        {
            init();


        }

 
        private void init()
        {
            //create panel
            infoPanel = (UIPanel)UIView.GetAView().AddUIComponent(typeof(UIPanel));
            infoPanel.size = size;
            infoPanel.name = "infoPanel";
            infoPanel.color = new Color32(0, 0, 100, 230);

            //init some settings
            infoPanel.backgroundSprite = "GenericPanel";
            infoPanel.autoLayoutDirection = LayoutDirection.Vertical;
            infoPanel.autoLayoutStart = LayoutStart.TopLeft;
            infoPanel.autoLayout = true;
            infoPanel.autoLayoutPadding = new RectOffset(0, 0, 0, 0);
            infoPanel.CenterToParent();
            infoPanel.eventClick += new MouseEventHandler(panelClick);

            //not sure if even needed
            infoPanel.Start();
            infoPanel.Update();


            //header Panel
            UIPanel headerpanel;
            headerpanel = (UIPanel)infoPanel.AddUIComponent(typeof(UIPanel));
            headerpanel.height = 35;
            headerpanel.width = size.x;
            headerpanel.backgroundSprite = "GenericPanel";
            headerpanel.color = new Color32(0, 0, 100, 200);

            //header text
            UILabel headertext;
            headertext = headerpanel.AddUIComponent<UILabel>();
            headertext.text = "City Zones";
            headertext.CenterToParent();

            infoPanel.BringToFront();
            infoPanel.position = new Vector3(-Screen.width + (size.x + 110), (size.y/2) + 40, 0);


        }//end init

        void panelClick(UIComponent component, UIMouseEventParameter eventParam)
        {
            SaveData.getData();

        }//end panel click



    }

}