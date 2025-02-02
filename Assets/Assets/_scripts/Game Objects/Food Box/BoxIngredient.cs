using UnityEngine;

namespace Space.Objects
{
    // Classe filha para caixas que carregam ingredientes
    public class BoxIngredient : Box
    {
        public string nameIngredient;
        public Sprite spriteIngredient;

        protected override void Awake()
        {
            base.Awake(); // Chama o Awake() da classe pai (Box)
        }

        void Start()
        {
            AddPlaceholder();
        }

        void AddPlaceholder()
        {
            if (spriteIngredient == null)
            {
                spriteRenderer.color = Color.gray; // Placeholder sem precisar de textura
            }
            else
            {
                spriteRenderer.sprite = spriteIngredient;
            }
        }

        public void SetIngredient(string nome, Sprite novoSprite)
        {
            nameIngredient = nome;
            spriteIngredient = novoSprite;
            spriteRenderer.sprite = novoSprite;
        }
    }
}
