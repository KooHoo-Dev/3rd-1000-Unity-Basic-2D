using Study_OOP_And_Design_Pattern.Structural.Composite;
using UnityEngine;

public class FileTreeDemo : MonoBehaviour
{
    private void Start()
    {
        Folder root = new Folder("A")
            .Add(new File("교안A.txt", 4))
            .Add(new Folder("B")
                .Add(new File("교안B-1.txt", 4))
                .Add(new File("교안B-2.txt", 4)))
            .Add(new Folder("C")
                .Add(new File("교안C-1.txt", 4)))
            .Add(new Folder("D"))
            .Add(new File("기타 교안 F-1", 16))
            .Add(new File("기타 교안 F-2", 16))
            .Add(new File("기타 교안 F-3", 16));

            
        root.Print(0);
        Debug.Log($"Size = {root.Size()}");
    }
}