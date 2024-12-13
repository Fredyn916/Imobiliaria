<template>
    <nav class="NavBar">
        <div class="InsideNavBar" :class="{ show: menuVisible }">
            <RouterLink to="/" class="Home__Bnt" @click="hideMenu">Inicio</RouterLink>
            <MenusNav @menuClicked="hideMenu" />
            <ul class="Nav__actions">
                <li class="li__Home">
                    <RouterLink to="BeforeAddImovel" class="Anunce__Bnt" @click="hideMenu">Anunciar Gratis</RouterLink>
                    <div v-if="usuario === null">
                        <RouterLink to="Login" class="Entry__Bnt" @click="hideMenu">Entrar</RouterLink>
                    </div>
                    <div v-else>
                        <RouterLink to="UsuarioPage" class="Entry__Bnt" @click="hideMenu">{{ usuario.username }}
                        </RouterLink>
                    </div>
                </li>
            </ul>
        </div>
        <div class="Menu__icon__container">
            <RouterLink to="/"><img src="@/Images/logo.png" alt="logo" width="20px"></RouterLink>
            <button class="NavBar__icon-btn" id="navToggle" @click="toggleMenu">
                <img src="@/Images/menu.svg" alt="menu" class="Header__icon" width="30px">
            </button>
        </div>
    </nav>
</template>


<script>
import MenusNav from '@/components/MenusNav.vue';

export default {
    name: 'MobileNavBar',
    components: {
        MenusNav
    },
    data() {
        return {
            menuVisible: false
        };
    },
    computed: {
        usuario() {
            const usuario = this.$store.getters.getUsuario;
            console.log('usuario:', usuario);
            return usuario;
        }
    },
    methods: {
        toggleMenu() {
            this.menuVisible = !this.menuVisible;
        },
        hideMenu() {
            this.menuVisible = false;
        }
    }
}
</script>


<style scoped>
.NavBar {
    display: flex;
    /* Utiliza flexbox para organizar os itens da barra de navegação */
    justify-content: space-between;
    /* Espaça os itens ao máximo, colocando-os nas extremidades */
    padding-inline: 12rem;
    /* Adiciona espaçamento horizontal interno (direita e esquerda) */
    align-items: center;
    /* Alinha verticalmente os itens ao centro */
    height: 60px;
    /* Define a altura da barra de navegação */
    margin: 0 auto;
    /* Centraliza a barra de navegação */
    width: 100%;
    /* A barra de navegação ocupa 100% da largura disponível */
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
    /* Adiciona uma sombra sutil à barra de navegação */
}

.Nav__actions {
    display: flex;
    /* Organiza os itens de ação em uma linha */
    gap: 20px;
    /* Espaçamento de 20px entre os itens */
    list-style: none;
    /* Remove os marcadores de lista */
    padding: 0;
    /* Remove o padding */
    margin: 0;
    /* Remove a margem */
}

.li__Home {
    display: flex;
    /* Organiza os itens de home em uma linha */
    gap: 20px;
    /* Espaçamento de 20px entre os itens */
}

.Anunce__Bnt {
    background-color: transparent;
    /* Fundo transparente para o botão */
    border: none;
    /* Remove a borda do botão */
    color: #2C3E50;
    /* Cor do texto do botão */
    padding: 0.90rem 1.5rem;
    /* Adiciona espaçamento interno ao botão */
    text-align: center;
    /* Centraliza o texto do botão */
    text-decoration: none;
    /* Remove o sublinhado do texto */
    font-size: 12px;
    /* Define o tamanho da fonte */
    cursor: pointer;
    /* Muda o cursor para ponteiro ao passar sobre o botão */
    border-radius: 10px;
    /* Adiciona bordas arredondadas ao botão */
    transition: background-color 0.3s;
    /* Adiciona transição suave para a cor de fundo */
}

.Anunce__Bnt:hover {
    background-color: #505050;
    /* Altera a cor de fundo ao passar o mouse */
    color: #FFF;
    /* Altera a cor do texto ao passar o mouse */
}

.Home__Bnt {
    background-color: transparent;
    /* Fundo transparente para o botão */
    border: none;
    /* Remove a borda do botão */
    color: black;
    /* Cor do texto do botão */
    padding: 0.90rem 1.5rem;
    /* Adiciona espaçamento interno ao botão */
    text-align: center;
    /* Centraliza o texto do botão */
    text-decoration: none;
    /* Remove o sublinhado do texto */
    font-size: 12px;
    /* Define o tamanho da fonte */
    cursor: pointer;
    /* Muda o cursor para ponteiro ao passar sobre o botão */
    border-radius: 10px;
    /* Adiciona bordas arredondadas ao botão */
    transition: background-color 0.3s;
    /* Adiciona transição suave para a cor de fundo */
}

.Home__Bnt:hover {
    background-color: #505050;
    /* Altera a cor de fundo ao passar o mouse */
    color: #FFF;
    /* Altera a cor do texto ao passar o mouse */
}

.Entry__Bnt {
    background-color: rgb(0, 43, 82);
    /* Cor de fundo do botão */
    border: none;
    /* Remove a borda do botão */
    color: white;
    /* Cor do texto do botão */
    padding: 0.90rem 1.5rem;
    /* Adiciona espaçamento interno ao botão */
    text-align: center;
    /* Centraliza o texto do botão */
    text-decoration: none;
    /* Remove o sublinhado do texto */
    display: inline-block;
    /* Exibe o botão como um bloco em linha */
    font-size: 12px;
    /* Define o tamanho da fonte */
    cursor: pointer;
    /* Muda o cursor para ponteiro ao passar sobre o botão */
    border-radius: 10px;
    /* Adiciona bordas arredondadas ao botão */
    transition: background-color 0.3s;
    /* Adiciona transição suave para a cor de fundo */
}

.Entry__Bnt:hover {
    background-color: #1A5276;
    /* Altera a cor de fundo ao passar o mouse */
}

.Menu__icon__container {
    display: flex;
    /* Organiza os itens da navegação em uma linha */
    justify-content: space-between;
    /* Espaça os itens ao máximo */
    align-items: center;
    /* Alinha os itens verticalmente ao centro */
    width: 100%;
    /* A largura ocupa 100% do elemento pai */
}

.NavBar__icon-btn {
    display: none;
    /* Inicialmente, o botão do ícone de menu está oculto */
    border: none;
    /* Remove a borda do botão */
    background-color: transparent;
    /* Fundo transparente */
    padding: 0;
    /* Remove o padding */
    outline: none;
    /* Remove a borda de foco */
    display: inline-block;
    /* Exibe o botão como um bloco em linha */
}

.NavBar__icon-btn:hover {
    cursor: pointer;
    /* Muda o cursor para ponteiro ao passar sobre o ícone */
    transform: scale(1.1);
    /* Aumenta ligeiramente o tamanho do ícone ao passar o mouse */
}

.Header__icon {
    width: 1.75rem;
    /* Define a largura do ícone */
    height: 1.75rem;
    /* Define a altura do ícone */
}

@media (max-width: 1280px) {
    .NavBar__icon-btn {
        display: block;
        /* Exibe o botão do ícone em telas menores */
    }

    .InsideNavBar {
        display: none;
        /* Inicialmente oculta a barra de navegação interna */
    }

    .NavBar {
        display: flex;
        /* Organiza a barra de navegação usando flexbox */
        justify-content: space-around;
        /* Espaça os itens uniformemente */
        padding-inline: 2rem;
        /* Adiciona padding horizontal */
    }

    .InsideNavBar.show {
        display: flex;
        /* Exibe a navegação interna quando a classe 'show' é aplicada */
        flex-direction: column;
        /* Organiza os itens em uma coluna */
        position: absolute;
        /* Posiciona a navegação de forma absoluta */
        text-align: center;
        /* Centraliza o texto */
        align-items: center;
        /* Alinha os itens ao centro */
        justify-content: center;
        /* Alinha os itens ao centro */
        top: 60px;
        /* Posiciona a navegação abaixo da barra de navegação */
        right: 0;
        /* Alinha à direita */
        width: 20%;
        /* Define a largura da navegação interna */
        height: 100vh;
        /* A altura ocupa 100% da altura da tela */
        max-height: 100vh;
        /* Limita a altura a 100% da tela */
        background-color: #fff;
        /* Define o fundo branco */
        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
        /* Adiciona sombra */
        z-index: 1000;
        /* Garante que a navegação ficará acima de outros elementos */
    }

    .li__Home {
        display: flex;
        /* Organiza os itens da home em uma coluna */
        flex-direction: column;
        /* Organiza os itens em coluna */
    }

    .Nav__actions {
        display: flex;
        /* Organiza os itens de ação em uma linha */
        align-items: center;
        /* Alinha os itens ao centro */
        gap: 20px;
        /* Espaçamento entre os itens */
        list-style: none;
        /* Remove o estilo de lista */
        padding: 0;
        /* Remove o padding */
        margin: 0;
        /* Remove a margem */
    }
}

@media (max-width: 768px) {
    .InsideNavBar.show {
        display: block;
        /* Exibe a navegação interna quando a classe 'show' é aplicada */
        display: flex;
        /* Organiza os itens da navegação interna em linha */
        gap: 2rem;
        /* Adiciona espaçamento entre os itens */
        width: 100%;
        /* A largura ocupa 100% da tela */
    }

    .Anunce__Bnt {
        background-color: transparent;
        /* Fundo transparente */
        border: 1px solid black;
        /* Borda preta */
        color: black;
        /* Cor do texto preta */
        padding: 0.90rem 6.5rem;
        /* Espaçamento interno grande no botão */
        text-align: center;
        /* Centraliza o texto */
        text-decoration: none;
        /* Remove o sublinhado */
        font-size: 12px;
        /* Define o tamanho da fonte */
        cursor: pointer;
        /* Muda o cursor para ponteiro */
        border-radius: 10px;
        /* Bordas arredondadas */
        transition: background-color 0.3s;
        /* Transição suave para a cor de fundo */
    }

    .Home__Bnt {
        background-color: transparent;
        /* Fundo transparente */
        border: 1px solid black;
        /* Borda preta */
        color: black;
        /* Cor do texto preta */
        padding: 0.90rem 8rem;
        /* Espaçamento interno maior */
        text-align: center;
        /* Centraliza o texto */
        text-decoration: none;
        /* Remove o sublinhado */
        font-size: 12px;
        /* Define o tamanho da fonte */
        cursor: pointer;
        /* Muda o cursor para ponteiro */
        border-radius: 10px;
        /* Bordas arredondadas */
        transition: background-color 0.3s;
        /* Transição suave para a cor de fundo */
    }
}
</style>
