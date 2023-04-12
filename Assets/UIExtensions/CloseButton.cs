using UnityEngine;
using UnityEngine.UI;

namespace Tais.Scenes.UIExtensions
{
    public class CloseButton : MonoBehaviour
    {
        public GameObject target;

        // Start is called before the first frame update
        void Start()
        {
            this.GetComponent<Button>().onClick.AddListener(() => Destroy(target));
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
