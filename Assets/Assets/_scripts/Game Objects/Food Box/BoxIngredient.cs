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
            base.Awake();
        }

        void Start()
        {
            AddPlaceholder();
        }

        void AddPlaceholder()
        {
            if (spriteIngredient == null)
            {
                spriteRenderer.color = Color.gray;
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
