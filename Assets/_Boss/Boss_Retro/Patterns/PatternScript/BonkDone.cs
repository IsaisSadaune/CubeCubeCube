using System;
using Unity.Behavior;
using UnityEngine;
using Unity.Properties;

#if UNITY_EDITOR
[CreateAssetMenu(menuName = "Behavior/Event Channels/BonkDone")]
#endif
[Serializable, GeneratePropertyBag]
[EventChannelDescription(name: "BonkDone", message: "Bonk has been Done", category: "Events", id: "2a39bed5afca7ebf33cc77edce044634")]
public sealed partial class BonkDone : EventChannel { }

