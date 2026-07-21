using Study_OOP_And_Design_Pattern.Structural.Composite;
using UnityEngine;

public class GenericTreeDemo : MonoBehaviour
{
    private void Start()
    {
        TreeNode<string> root = new TreeNode<string>("사장");
            
        TreeNode<string> dev = new TreeNode<string>("개발 팀장");
        dev.Add("클라이언트 A");
        dev.Add("클라이언트 B");
        dev.Add("서버 A");
            
        TreeNode<string> gameDesign = new TreeNode<string>("기획 팀장");
        gameDesign.Add("시스템 기획자 A");
        gameDesign.Add("시스템 기획자 B");
        gameDesign.Add("밸런스 기획자 A");
        gameDesign.Add("콘텐츠 기획자 A");
        gameDesign.Add("콘텐츠 기획자 B");
        gameDesign.Add("콘텐츠 기획자 C");
        gameDesign.Add("레벨 디자이너 A");
            
        TreeNode<string> art = new TreeNode<string>("아트 팀장");
        art.Add("아트 디렉터");
        art.Add("Environment Artist A");
        art.Add("Environment Artist B");
        art.Add("Character Artist B");
        art.Add("Character Artist B");

        root.Children.Add(dev);
        root.Children.Add(gameDesign);
        root.Children.Add(art);
            
        root.ForEach(PrintPosition,0);
        Debug.Log("======================");
        root.ForEach(Print,0);
    }

    private void PrintPosition(string str, int depth)
    {
        string empty = new string(' ', depth * 2);
        Debug.Log($"{empty} - {str}");
    }
        
    private void Print(string str, int depth)
    {
        string empty = new string(' ', depth * 2);
        Debug.Log($"{empty} - {depth}");
    }
}