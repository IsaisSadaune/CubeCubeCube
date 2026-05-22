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
        int rdmTile = UnityEngine.Random.Range(0, ArenaTiles.Value.Count);
        Path.Value.AddRange(FindPath(RetroBoss.Instance.transform.position, Player.Instance.transform.position));
        Path.Value.AddRange(FindPath(Player.Instance.transform.position, ArenaTiles.Value[rdmTile].transform.position));
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
        //Transforme l'arène en tiles
        List<Vector3> tilePositions = ArenaTiles.Value
        .Select(tile => SnapToGrid(tile.transform.position))
        .ToList();

        HashSet<Vector3> validPositions = new HashSet<Vector3>(tilePositions);

        Vector3 snappedStart  = GetClosestTiles(start, tilePositions);
        Vector3 snappedTarget = GetClosestTiles(target, tilePositions);

        HashSet<Vector3> closedSet = new HashSet<Vector3>();
        List<Node> Openlist = new List<Node>();

        
        Node startNode = new Node(snappedStart);   

        startNode.h = CalculateHeuristic(snappedStart, snappedTarget);
        startNode.f = startNode.h;
        Openlist.Add(startNode);

        while(Openlist.Count > 0)
        {
            Node currentNode = Openlist.OrderBy(n => n.f).ThenBy(n => n.h).First();
            Openlist.Remove(currentNode);
            closedSet.Add(currentNode.position);

            if(Vector3.Distance(currentNode.position, snappedTarget) < 1f)
            {
                return ReconstructPath(currentNode); // Path Trouvé
            }

            foreach(Node neighbor in GetNeighbors(currentNode, validPositions))
            {  
                if(closedSet.Contains(neighbor.position))
                continue;
                
                float tentativeG = currentNode.g + 1;

                Node existingNode = Openlist.FirstOrDefault(n => n.position == neighbor.position);

                if(existingNode == null)
                {
                    neighbor.g = tentativeG;
                    neighbor.h = CalculateHeuristic(neighbor.position, snappedTarget);
                    neighbor.f = neighbor.g + neighbor.h;
                    neighbor.parent = currentNode;
                    Openlist.Add(neighbor);
                }
                else if (tentativeG < existingNode.g)
                {
                    //Remplace la node existante par la nouvelle
                    existingNode.g = tentativeG;
                    existingNode.f = existingNode.g + existingNode.h;
                    existingNode.parent = currentNode;
                }
            }
        }
        Debug.Log("Pas de chemin trouvé");
        return new List<Vector3>(); 
    } 

    private Vector3 GetClosestTiles(Vector3 pos, List<Vector3> tilePositions)
    {
        return tilePositions.OrderBy(t => Vector3.Distance(t, pos)).First();
    }
    private List<Node> GetNeighbors(Node node, HashSet<Vector3> validPositions)
    {
        List<Node> neighbors = new List<Node>();
        Vector3[] directions = { Vector3.right*2, Vector3.left*2, Vector3.forward*2, Vector3.back*2 };

        foreach (var dir in directions)
        {
            Vector3 neighborPos = node.position + dir;
            //Cherche une tuile proche avec 0.5 de tolérance 
            Vector3? v = FindInSet(neighborPos, validPositions);
            if(v.HasValue)
            {
                neighbors.Add(new Node(v.Value));
            }
        }
        return neighbors;
    }
    private float CalculateHeuristic(Vector3 a, Vector3 b)
    {
        return Mathf.Abs(a.x - b.x) + Mathf.Abs(a.z - b.z);
    }

    private Vector3? FindInSet(Vector3 pos, HashSet<Vector3> validPositions)
    {
        foreach(var v in validPositions)
        {
            if(Vector3.Distance(v, pos) < 2f)
            {
                return v;
            }
        }
        return null;
    }
    private Vector3 SnapToGrid(Vector3 pos)
    {
        return new Vector3(Mathf.Round(pos.x), Mathf.Round(pos.y), Mathf.Round(pos.z));
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

