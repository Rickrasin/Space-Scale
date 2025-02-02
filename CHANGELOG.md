# Changelog

Todas as mudanças relevantes deste projeto serão registradas neste arquivo.

## [Unreleased]
### Added
- Implementação inicial do menu principal com opções e saída.

---

## [0.1.0] - Player Gameplay - 2025-02-02
### Added
- Novo estado de "carry" aprimorado com movimento suave para a caixa.
- Implementação de lógica para o personagem sempre olhar para a caixa.
- Novo sistema de interações que utilizar camadas para buscar objetos.

### Changed
- Refatoração do CoreSystem para facilitar a injeção de dependência.
- Ajustes na State Machine para melhorar a transição entre estados.
- Otimização do código de animação (detecção de final da animação).

### Fixed
- Corrigido bug em que o personagem não girava para a caixa quando carregando.
- Resolvido problema na liberação da caixa quando fora do collider.
- Ajustes finos no tempo de carry e drag para suavizar movimentos.

