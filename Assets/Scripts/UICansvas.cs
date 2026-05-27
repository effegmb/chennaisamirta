using UnityEngine;
using UnityEngine.Video;

public class UICansvas : MonoBehaviour
{
    [Header("Main Panel")]
    public GameObject mainPanel;
    public GameObject mainPanelButton;

    [Header("Menu Panel")]
    public GameObject menuPanel;
    public GameObject videoPlayImage;
    public GameObject aboutPanel;
    public GameObject coursePanel;
    public GameObject placementPanel;
    public GameObject valueAddedServicePanel;
    public GameObject supportAndServicePanel;

    [Header("Course Panel")]
    public GameObject alagappa;
    public GameObject unicam;
    public GameObject nehru;

    [Header("Value Added Service")]
    public VideoPlayer valueAddedVideoPlayer;
    public GameObject iataPanel;
    public GameObject inFlightPanel;
    public GameObject outBoundPanel;
    public GameObject communicationPanel;
    public GameObject pdcPanel;

    [Header("Support Service")]
    public GameObject studentPanel;
    public GameObject parentPanel;

    public void MainPanelButton()
    {
        mainPanel.SetActive(false);
        mainPanelButton.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void AboutButton()
    {
        videoPlayImage.SetActive(false);
        aboutPanel.SetActive(true);
        coursePanel.SetActive(false);
        placementPanel.SetActive(false);
        valueAddedServicePanel.SetActive(false);
        supportAndServicePanel.SetActive(false);
    }

    public void CourseButton() 
    {
        videoPlayImage.SetActive(false);
        aboutPanel.SetActive(false);
        coursePanel.SetActive(true);
        placementPanel.SetActive(false);
        valueAddedServicePanel.SetActive(false);
        supportAndServicePanel.SetActive(false);
    }
    public void PlacementButton() 
    {
        videoPlayImage.SetActive(false);
        placementPanel.SetActive(true);
        aboutPanel.SetActive(false);
        coursePanel.SetActive(false);
        valueAddedServicePanel.SetActive(false);
        supportAndServicePanel.SetActive(false);
    }

    public void ValueAddedServiceButton()
    {
        valueAddedServicePanel.SetActive(true);
        videoPlayImage.SetActive(false);
        placementPanel.SetActive(false);
        aboutPanel.SetActive(false);
        coursePanel.SetActive(false);
        supportAndServicePanel.SetActive(false);
    }

    public void SupportAndService()
    {
        supportAndServicePanel.SetActive(true);
        valueAddedServicePanel.SetActive(false);
        videoPlayImage.SetActive(false);
        placementPanel.SetActive(false);
        aboutPanel.SetActive(false);
        coursePanel.SetActive(false);
    }

    public void AlgappaEnterButton()
    {
        alagappa.SetActive(true);
    }
    public void AlgappaLeaveButton() 
    {
        alagappa.SetActive(false);
    }

    public void UnicamEnterButton()
    {
        unicam.SetActive(true);
    }

    public void UnicamExitButton()
    {
        unicam.SetActive(false);    
    }

    public void NehruEnterButton()
    {
        nehru.SetActive(true);
    }
    public void NehruExitBuuton()
    {
        nehru.SetActive(false);
    }

    public void IataEnterButton()
    {
        valueAddedVideoPlayer.Play();
        iataPanel.SetActive(true);
    }
    public void IataExitButton()
    {
        valueAddedVideoPlayer.Stop();
        iataPanel.SetActive(false);
    }
    public void InflightEnterButton()
    {
        valueAddedVideoPlayer.Play();
        inFlightPanel.SetActive(true);
    }
    public void InflightExitButton()
    {
        valueAddedVideoPlayer.Stop();
        inFlightPanel.SetActive(false);
    }
    public void OutBoundEnterButton()
    {
        valueAddedVideoPlayer.Play();
        outBoundPanel.SetActive(true);
    }
    public void OutBoundExitButton()
    {
        valueAddedVideoPlayer.Stop();
        outBoundPanel.SetActive(false);
    }
    public void CommunicationEnterButton()
    {
        valueAddedVideoPlayer.Play();
        communicationPanel.SetActive(true);
    }
    public void CommunicationExitButton()
    {
        valueAddedVideoPlayer.Stop();
        communicationPanel.SetActive(false);
    }
    public void PdcEnterButton()
    {
        valueAddedVideoPlayer.Play();
        pdcPanel.SetActive(true);
    }
    public void PdcExitBuuton()
    {
        valueAddedVideoPlayer.Stop();
        pdcPanel.SetActive(false);
    }

    public void StudentEnterButton()
    {
        studentPanel.SetActive(true);
    }
    public void StudentExitButton() 
    {
        studentPanel.SetActive(false);
    }
    public void ParentEnterButton()
    {
        parentPanel.SetActive(true);
    }
    public void ParentExitButton()
    {
        parentPanel.SetActive(false);
    }
}
