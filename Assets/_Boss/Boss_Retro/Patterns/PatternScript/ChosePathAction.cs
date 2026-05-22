using System;
using System.Collections.Generic;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using System.Linq;
using DG.Tweening;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "ChosePath", story: "Chosing a [path] with [ArenaTiles]", category: "Action", id: "f4c49deee498ba505a2fdb6b3b5e6c4b")]
public partial class ChosePathAction : Action
{
    [SerializeReference] public BlackboardVariable<List<Vector3>> Path;
    [SerializeReference] public BlackboardVariable<List<GameObject>> ArenaTiles;
    protected override Status OnStart()
    {
        Path.Value.Clear();
        int rdmPos = UnityEngine.Random.Range(0, ArenaTiles.Value.Count);
        Path.Value = FindPath(RetroBoss.Instance.transform.position, ArenaTiles.Value[rdmPos].transform.position);

        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }

    public List<Vector3> FindPath(Vector3 start, Vector3 target)
    {
        List<Node> Openlist = new List<Node>();
        List<Node> ClosedList = new List<Node>();

        Node currentNode = new Node(start);   

        currentNode.h = CalculateHeuristic(start, target);
        currentNode.f = currentNode.h;
        ClosedList.Add(currentNode);

        while(Openlist.Count > 0)
        {
            currentNode = Openlist.OrderBy(n => n.f).ThenBy(n => n.h).First();
            Openlist.Remove(currentNode);
            ClosedList.Add(currentNode);

            if(currentNode.position == target)
            {
                ReconstructPath(currentNode);
            }

        foreach(Node node in GetNeighbors(currentNode))
            {  
                if(!ClosedList.Any(n => n.position == node.position))
                {
                    node.g = currentNode.g + 1;
                    node.h = CalculateHeuristic(node.position, target);
                    node.f = node.g + node.h;
                    node.parent = currentNode;
                    if(Openlist.Any(n => n.position == node.position))
                    {
                        Node n = Openlist.Find(n => n.position == node.position);
                        if(n.g > node.g)
                        {
                            n.g = node.g;
                            n.f = node.g + n.h;
                            n.parent = currentNode;
                        }
                    }
                    else
                        Openlist.Add(node);
                }
            }
        }
        Debug.Log("List");
        return new List<Vector3>(); 
    } 

    private List<Node> GetNeighbors(Node node)
    {
        List<Node> neighbors = new List<Node>();
        Vector3[] directions =
        {
            Vector3.right, Vector3.left, Vector3.forward, Vector3.back
        };

        foreach(var dir in directions)
        {
            Vector3 neighborPos = node.position + dir;
            neighbors.Add(new Node(neighborPos));
        }
        return neighbors;
    }
    private float CalculateHeuristic(Vector3 a, Vector3 b)
    {
        return Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y);
    }

    private List<Vector3> ReconstructPath(Node endNode)
    {
        List<Vector3> path = new List<Vector3>();
        Node n = endNode;

        while(n != null)
        {
            path.Add(n.position);
            n = n.parent;
        }

        path.Reverse();
        path.RemoveAt(0);
        return path;
    }
}

