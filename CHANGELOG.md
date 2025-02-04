# Changelog

Todas as mudanças relevantes deste projeto serão registradas neste arquivo.

## [Unreleased]
### Added
- Implementação inicial do menu principal com opções e saída.

---

## [0.2.0] - Entrega e Melhorias no Carregamento - 2025-02-04
### Added
- Implementação do sistema de **entrega de caixas de comida** na Sala de Entrega.
- **Nova mecânica de carregamento** aprimorada para o player.
- **Sistema de colisão otimizado**, melhorando a interação com objetos carregáveis.
- Implementação de **artes para a Sala de Entrega**.

### Changed
- Melhorias no código da **State Machine do player** para um carregamento mais fluido.
- Refinamento da **mecânica de carregar e soltar caixas**.
- Ajuste no sistema de **camadas e detecção de colisões**, melhorando a interação com o ambiente.

### Fixed
- Resolvido bug onde **o player soltava a caixa antes do tempo correto**.
- Correção na **interação com a zona de entrega**, evitando entrega de caixas incorretas.
- Ajustes na **detecção de inputs** para evitar ações repetidas.
- Corrigido problema onde **as caixas ficavam presas ao soltar em algumas colisões**.


---

## [0.1.0] - Player Gameplay - 2025-02-02
### Added
- Novo estado de "carry" aprimorado com movimento suave para a caixa.
- Implementação de lógica para o personagem sempre olhar para a caixa.
- Novo sistema de interações que utiliza camadas para buscar objetos.

### Changed
- Refatoração do CoreSystem para facilitar a injeção de dependência.
- Ajustes na State Machine para melhorar a transição entre estados.
- Otimização do código de animação (detecção de final da animação).

### Fixed
- Corrigido bug em que o personagem não girava para a caixa quando carregando.
- Resolvido problema na liberação da caixa quando fora do collider.
- Ajustes finos no tempo de carry e drag para suavizar movimentos.
