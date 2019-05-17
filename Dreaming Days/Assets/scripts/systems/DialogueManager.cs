using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public GameObject[] Buttons;
    public GameObject ContinueButton;
    public GameObject endButton;
    public Animator animator;

    private Queue<Sentence> sentences;
    private int choiceSelected = 1;
    // Start is called before the first frame update
    void Start()
    {
     sentences = new Queue<Sentence>();   
    } // End Start


    public void StartDialogue(Dialogue dialogue){
      //Debug.Log("Starting conversation");
      nameText.text = dialogue.name;
      animator.SetBool("isOpen", true);
      sentences.Clear();
      foreach(Sentence sentence in dialogue.sentences){
        sentences.Enqueue(sentence);
      }
      DisplayNextSentence();
    } //End StartDialogue

    //Displaying Next Sentence
    public void DisplayNextSentence(){
      if(sentences.Count == 0){
        EndDialogue();
        return;
      } else if(sentences.Count == 1){
        ContinueButton.gameObject.SetActive(false);
        endButton.gameObject.SetActive(true);
      }
      Sentence sentence = sentences.Dequeue();
      string the_sentence;
      if(sentence.doesChoiceMatter){

       the_sentence = sentence.words[choiceSelected-1];
      } else{
        the_sentence = sentence.words[0];
      }

      StopAllCoroutines();
      StartCoroutine(TypeSentence(the_sentence));
      if(sentence.hasChoice){
        int counter = 0;
        foreach(string choice in sentence.option.options){
          Buttons[counter].gameObject.SetActive(true);
          GameObject test = Buttons[counter].gameObject.transform.GetChild(0).gameObject;
          test.GetComponent<Text>().text  = choice;
          counter++;
        }
        ContinueButton.gameObject.SetActive(false);
      } else{
        for(int i = 0; i < Buttons.Length; i++){
          Buttons[i].gameObject.SetActive(false);
        }
        ContinueButton.gameObject.SetActive(true);
      }
      //Debug.Log(sentence);
    } //End DisplayNextSentence

    void EndDialogue(){
      //Debug.Log("End of Conversation");
      animator.SetBool("isOpen", false);
    } //End EndDialogue


    IEnumerator TypeSentence(string sentence){
      dialogueText.text = "";
      foreach (char letter in sentence.ToCharArray()){
        int count = 0;
        dialogueText.text += letter;
        while(count != 2){
          yield return null;
          count++;
        }
      }
    } //End TypeSentence

    public void selectOption(int i){
      choiceSelected = i;
      DisplayNextSentence();
    }

    public int getChoice(){
      return choiceSelected;
    }
}
