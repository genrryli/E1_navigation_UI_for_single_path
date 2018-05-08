using UnityEngine;
using System.Collections;

namespace FluffyUnderware.DevTools
{
    public class InspectorNote : MonoBehaviour 
    {

        [TextArea(5,20)]
        [SerializeField]
        string m_Note;
    }
}