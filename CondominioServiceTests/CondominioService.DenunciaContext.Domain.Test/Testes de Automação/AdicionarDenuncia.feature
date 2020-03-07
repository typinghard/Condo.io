Funcionalidade: Denuncia - Adicionar denúncia
	Como um usuário
	Eu desejo adicionar uma denúncia

Cenário: Adicionar denúncia com sucesso
Dado O usuário esteja na tela inicial
E O usuário clicou em Adicionar Denuncia
Quando O usuário preencher os dados da nova denuncia
		| Dados     |
		| Descricao |
E Clicar no botão Gravar		
Então O usuário será redirecionado para a tela de visualização de denúncias

Cenário: Tentar adicionar denúncia sem campos obrigatórios
Dado O usuário esteja na tela inicial
E O usuário clicou em Adicionar Denuncia
Quando Clicar no botão Gravar		
Então O usuário receberá avisos sobre campos obrigatórios não preenchidos
