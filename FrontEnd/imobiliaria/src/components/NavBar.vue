<template>
    <nav class="NavBar">
        <MenusNav />
        <ul class="Nav__actions">
            <li class="li__Home">
                <RouterLink to="BeforeAddImovel" class="Anunce__Bnt">Anunciar Gratis</RouterLink>
                <div v-if="!usuario">
                    <RouterLink to="Login" class="Entry__Bnt">Entrar</RouterLink>
                </div>
                <div v-else>
                    <RouterLink to="UsuarioPage" class="Entry__Bnt">Olá, {{ usuario.username }}</RouterLink>
                </div>
            </li>
        </ul>
    </nav>
</template>


<script>
import MenusNav from '@/components/MenusNav.vue';

export default {
    name: 'NavBar',
    components: {
        MenusNav
    },
    computed: {
        usuario() {
            return this.$store.getters.getUsuario;
        }
    }
}
</script>
<style scoped>
.NavBar {
    display: flex;
    /* Organiza os itens da barra de navegação com Flexbox */
    justify-content: space-between;
    /* Espaça os itens ao máximo, alinhando-os nas extremidades */
    padding-inline: 12rem;
    /* Adiciona espaçamento horizontal (direita e esquerda) dentro da barra */
    align-items: center;
    /* Alinha os itens verticalmente ao centro */
    height: 60px;
    /* Define a altura da barra de navegação */
    max-width: 100%;
    /* Impede que a largura da barra ultrapasse 100% da tela */
    margin: 0 auto;
    /* Centraliza a barra horizontalmente */
    width: 100%;
    /* A barra ocupa 100% da largura da tela */
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
    /* Adiciona sombra suave ao redor da barra */
}

.Nav__actions {
    display: flex;
    /* Organiza os itens da lista de ações em uma linha */
    gap: 20px;
    /* Espaçamento de 20px entre os itens */
    list-style: none;
    /* Remove os marcadores de lista */
    padding: 0;
    /* Remove o padding da lista */
    margin: 0;
    /* Remove a margem da lista */
}

.li__Home {
    display: flex;
    /* Organiza os itens de home em uma linha */
    gap: 20px;
    /* Espaçamento de 20px entre os itens */
}

.Anunce__Bnt {
    background-color: transparent;
    /* Define o fundo transparente do botão */
    border: none;
    /* Remove a borda do botão */
    color: #2C3E50;
    /* Cor do texto do botão */
    font-weight: bold;
    /* Define o texto em negrito */
    padding: 0.90rem 1.5rem;
    /* Adiciona espaçamento interno ao botão */
    text-align: center;
    /* Centraliza o texto dentro do botão */
    text-decoration: none;
    /* Remove o sublinhado do texto */
    font-size: 12px;
    /* Define o tamanho da fonte */
    cursor: pointer;
    /* Exibe o cursor como um ponteiro ao passar sobre o botão */
    border-radius: 10px;
    /* Adiciona bordas arredondadas ao botão */
    transition: 0.2s;
    /* Aplica transição suave de 0.2s para a interação */
}

.Anunce__Bnt:hover {
    background-color: #ededed;
    /* Altera a cor de fundo ao passar o mouse */
    color: #000;
    /* Altera a cor do texto para preto ao passar o mouse */
    transform: scale(1.05);
    /* Aumenta ligeiramente o tamanho do botão ao passar o mouse */
}

.Entry__Bnt {
    background-color: rgb(0, 43, 82);
    /* Cor de fundo azul escuro para o botão */
    border: none;
    /* Remove a borda do botão */
    color: white;
    /* Cor do texto do botão em branco */
    padding: 0.90rem 1.5rem;
    /* Adiciona espaçamento interno ao botão */
    text-align: center;
    /* Centraliza o texto dentro do botão */
    text-decoration: none;
    /* Remove o sublinhado do texto */
    display: inline-block;
    /* Exibe o botão como um bloco em linha */
    font-size: 12px;
    /* Define o tamanho da fonte */
    cursor: pointer;
    /* Exibe o cursor como um ponteiro ao passar sobre o botão */
    border-radius: 10px;
    /* Adiciona bordas arredondadas ao botão */
    transition: background-color 0.3s;
    /* Aplica transição suave para a cor de fundo */
    transition: .3s;
    /* Define o tempo de transição para 0.3s */
}

.Entry__Bnt:hover {
    background-color: #1A5276;
    /* Altera a cor de fundo ao passar o mouse */
    transform: scale(1.05);
    /* Aumenta ligeiramente o tamanho do botão ao passar o mouse */
    font-weight: bold;
    /* Define o texto do botão em negrito ao passar o mouse */
}

/* Media query para telas com largura entre 200px e 600px */
@media (min-width: 200px) and (max-width: 600px) {
    .NavBar {
        display: flex;
        /* Organiza a barra de navegação com Flexbox */
        justify-content: space-between;
        /* Espaça os itens ao máximo, nas extremidades */
        flex-direction: column;
        /* Organiza os itens da barra em uma coluna */
        padding-inline: 12rem;
        /* Adiciona espaçamento horizontal (direita e esquerda) dentro da barra */
        align-items: center;
        /* Alinha os itens verticalmente ao centro */
        height: 400px;
        /* Define a altura da barra para telas menores */
        max-width: 100%;
        /* Impede que a largura ultrapasse 100% */
        margin: 0 auto;
        /* Centraliza a barra horizontalmente */
        width: 100%;
        /* A largura ocupa 100% da tela */
        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
        /* Adiciona sombra suave */
    }
}

/* Media query para telas com largura menor que 1280px */
@media(width < 1280px) {
    .NavBar {
        display: none;
        /* Oculta a barra de navegação em telas pequenas */
    }
}
</style>
