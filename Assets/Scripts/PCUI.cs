using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class PCUI : MonoBehaviour
{
    public static PCUI pCUI;

    public Image[] apps, driversComplated;

    public GameObject installScreen, deInstallScreen, completedScan, programYukleKaldirApp, virusScannerApp, driverBoosterApp, restarPCScreen, formatScreen,closeScreen;

    public Image installApps, deInstallApps, installBar, deInstalBar, virusScannerBar, driverBar, windowsInstallBar, gpuMhzBar, cpuMhzBar, memMhzBar, tempCbar;

    public InputField windowsKeyField;

    public Text scannedFilesText, driverInstalPerAgeText, installPercentText, deInstallPercentText, windowsKeyText, enterKeyText, virusFoundText, gpuMhzText, cpuMhzText, memMhzText, tempCText;

    float scannedFiles, driverInstalPerAge, virusFound, gpuMhz = 750, cpuMhz = 750, memMhz = 750, tempC = 75;

    EventSystem eventSystem;

    public float timer1, timer2, timer3, timer4;

    public GameObject[] pointClose,afterRestartCloseObject;

    public bool isOpen;

    bool trueKey;


    private void Awake()
    {

        eventSystem = EventSystem.current;

        pCUI = this;

     
    }
    private void OnEnable()
    {
        eventSystem = EventSystem.current;

        pCUI = this;

       
    }



    private void Update()
    {

        if (!PCCase.pCCase.pcCanOpen)
        {

            closeScreen.SetActive(true);
            PowerButton.powerButton.CloseB();

        }

        if (!isOpen)
        {
            closeScreen.SetActive(true);
        }





        if (trueKey)
        {
            windowsKeyText.text = "% " + (windowsInstallBar.fillAmount * 100).ToString("F0");
        }


        if (windowsKeyField.isFocused && enterKeyText.text.Length > 1)
        {


            enterKeyText.text = "l";
        }



        if (installScreen.activeSelf)
        {
            installPercentText.text = "% " + (installBar.fillAmount * 100).ToString("F0");

        }

        if (deInstallScreen.activeSelf)
        {
            deInstallPercentText.text = "% " + (deInstalBar.fillAmount * 100).ToString("F0");

        }







        if (virusScannerApp.activeSelf)
        {
            scannedFilesText.text = scannedFiles.ToString();

            virusFoundText.text = virusFound.ToString();


        }

        if (driverBoosterApp.activeSelf)
        {


            driverInstalPerAgeText.text = driverInstalPerAge.ToString();



            gpuMhzText.text = gpuMhz.ToString();

            cpuMhzText.text = cpuMhz.ToString();

            memMhzText.text = memMhz.ToString();

            tempCText.text = tempC.ToString();


            gpuMhzBar.fillAmount = (float)gpuMhz / 1000;
            cpuMhzBar.fillAmount = (float)cpuMhz / 1000;
            memMhzBar.fillAmount = (float)memMhz / 1000;
            tempCbar.fillAmount = (float)tempC / 100;

            if (gpuMhz > 1000)
            {
                gpuMhz = 1000;
            }
            if (gpuMhz < 500)
            {
                gpuMhz = 500;
            }


            if (cpuMhz > 1000)
            {
                cpuMhz = 1000;
            }
            if (cpuMhz < 500)
            {
                cpuMhz = 500;
            }


            if (memMhz > 1000)
            {
                memMhz = 1000;
            }
            if (memMhz < 500)
            {
                memMhz = 500;
            }


            if (tempC > 100)
            {
                tempC = 100;
            }
            if (tempC < 50)
            {
                tempC = 50;
            }






            if (Time.time > timer1)
            {
                ;
                DOTween.To(() => (int)gpuMhz, x => gpuMhz = x, (int)Mathf.Clamp(Random.Range(gpuMhz - 75, gpuMhz + 75), 500, 1000), 3.6f);

                timer1 = Time.time + 8.5f;

            }

            if (Time.time > timer2)
            {
                DOTween.To(() => (int)cpuMhz, x => cpuMhz = x, (int)Mathf.Clamp(Random.Range(cpuMhz - 75, cpuMhz + 75), 500, 1000), 5f);



                timer2 = Time.time + 10f;
            }

            if (Time.time > timer3)
            {
                DOTween.To(() => (int)memMhz, x => memMhz = x, (int)Mathf.Clamp(Random.Range(memMhz - 75, memMhz + 75), 500, 1000), 2.6f);



                timer3 = Time.time + 6f;

            }

            if (Time.time > timer4)
            {
                DOTween.To(() => (int)tempC, x => tempC = x, (int)Mathf.Clamp(Random.Range(tempC - 5, tempC + 5), 50, 100), 1f);



                timer4 = Time.time + 4f;
            }




            if (driverInstalPerAge < 12)
            {
                driversComplated[0].gameObject.SetActive(false);
                driversComplated[1].gameObject.SetActive(false);
                driversComplated[2].gameObject.SetActive(false);
                driversComplated[3].gameObject.SetActive(false);
            }

            if (driverInstalPerAge > 12)
            {
                driversComplated[0].gameObject.SetActive(true);
                driversComplated[1].gameObject.SetActive(false);
                driversComplated[2].gameObject.SetActive(false);
                driversComplated[3].gameObject.SetActive(false);
            }

            if (driverInstalPerAge > 45)
            {
                driversComplated[1].gameObject.SetActive(true);
                driversComplated[2].gameObject.SetActive(false);
                driversComplated[3].gameObject.SetActive(false);
            }

            if (driverInstalPerAge > 65)
            {
                driversComplated[2].gameObject.SetActive(true);
                driversComplated[3].gameObject.SetActive(false);
            }

            if (driverInstalPerAge > 85)
            {
                driversComplated[3].gameObject.SetActive(true);
            }

        }

    }







    public void OpenCloseButton(GameObject openObject)
    {
        if (openObject.activeSelf)
        {
           
            openObject.SetActive(false);
        }

        else
        {
            openObject.SetActive(true);
            for (int i = 0; i < pointClose.Length; i++)
            {
                pointClose[i].SetActive(true);
            }
        }
       


    }

 
    




    public void CloseApp(GameObject apps)
    {
        apps.SetActive(false);
    }

    public void ClearEnterText()
    {
        enterKeyText.enabled =false;
        windowsKeyText.text = "I";
    }

    public void WindowsKey()
   {

      

        windowsKeyText.text = "";

        for (int i = 0; i < windowsKeyField.text.Length; i++)
        {
            if (i < windowsKeyField.text.Length-1)
            {
               

                if (!windowsKeyField.text[i].Equals(' ')&&i == windowsKeyField.text.Length - 1)
                {
                    windowsKeyText.text += windowsKeyField.text[i];

                }

                else if(!windowsKeyField.text[i].Equals(' ')&& i <= windowsKeyField.text.Length - 2)
                {
                    if (!windowsKeyField.text[i+1].Equals(' '))
                    {
                        windowsKeyText.text += windowsKeyField.text[i] + "-";

                    }
                    else
                    {
                        windowsKeyText.text += windowsKeyField.text[i];
                    }
                }


                else
                {
                    windowsKeyText.text += windowsKeyField.text[i];
                }


            }

            else
            {
                windowsKeyText.text += windowsKeyField.text[i];
            }
         

        }

        if(windowsKeyField.text=="vatan game jam"|| windowsKeyField.text == "VATAN GAME JAM" || windowsKeyField.text == "VATANGAMEJAM" || windowsKeyField.text == "vatangamejam" || windowsKeyField.text == "333333333" || windowsKeyField.text == "Stratera"||windowsKeyField.text == "grimnax" || windowsKeyField.text == "GRIMNAX" || windowsKeyField.text == "Grimnax" || windowsKeyField.text == "stratera")
        {
            StartFormat();
            trueKey = true;
        }
    }

    private void StartFormat()
    {
  
        DOTween.To(() => 0.01f, x => windowsInstallBar.fillAmount = x, 1, Random.Range(5f, 7)).OnComplete(()=>RestartPc());
        enterKeyText.text = "Enter Windows Key...";
        windowsInstallBar.fillAmount = 0;
        windowsKeyField.text = "";
        trueKey = false;
    }
    public void RestartPc()
    {
        closeScreen.SetActive(false);
        restarPCScreen.SetActive(true);

        for (int i = 0; i < afterRestartCloseObject.Length; i++)
        {
            afterRestartCloseObject[i].SetActive(false);
        }

        float timer;

        DOTween.To(() => 0.01f, x => timer = x, 1, Random.Range(3.2f, 5.1f)).OnComplete(() => OpenPC());


    }

   public void ClosePc()
    {
        isOpen = false;
        PowerButton.powerButton.CloseB();
    }


    public void OpenPC()
    {

       PC.pc.ShowApps();

        restarPCScreen.SetActive(false);
      
        formatScreen.SetActive(false);
    }






    public void StartVirusScanner()
    {
        completedScan.SetActive(false);

        eventSystem.enabled = false;

        float random;

        random = Random.Range(1.01f, 2.75f);

        DOTween.To(() => 0.001f, x => virusScannerBar.fillAmount = x, 1, random).OnComplete(() => EndVirusScanner());
    
        DOTween.To(() => 0, x => scannedFiles = x, Random.Range(30000,50000), random);

        DOTween.To(() => 0, x => virusFound = x, Random.Range(3, 50), random);
    }


    public void InstallDriver()
    {
        float random;

        random = Random.Range(2.51f, 5.75f);


        DOTween.To(() => 0.001f, x => driverBar.fillAmount = x, 1, random).OnComplete(() => EndInstallDriver());

        DOTween.To(() => 0, x => driverInstalPerAge = x, 100, random);

        eventSystem.enabled = false;
    }

    void EndInstallDriver()
    {
      

        eventSystem.enabled = true;
    }



    void EndVirusScanner()
    {
        completedScan.SetActive(true);
        
        eventSystem.enabled = true;
    }



   

}
