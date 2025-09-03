using TMPro;
using UnityEngine;

namespace Game.Infrastructure
{
    public class GameplayStatItemView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI countText;

        public void SetCounts(int counts)
        {
            countText.text = counts.ToString();
        }
    }
}