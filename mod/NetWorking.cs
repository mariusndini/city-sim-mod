

using System;
using UnityEngine;
using System.Collections;
using ColossalFramework.UI;

namespace data
{
    class NetWorking : MonoBehaviour
    {
        ExceptionPanel panel;

        public NetWorking()
        {
            panel = UIView.library.ShowModal<ExceptionPanel>("ExceptionPanel");

            //StartCoroutine(start());

        }

        IEnumerator start()
        {
            string url = "https://www.google.com";

            using (WWW www = new WWW(url))
            {
                yield return www;
                panel.SetMessage("City Citizen", "" + "WWW", false);

            }
        }



    }
}
