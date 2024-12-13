<template>
    <header>
        <nav>
            <ul class="Nav__ul">
                <div class="logo">
                    <RouterLink to="/">
                        <img src="https://res.cloudinary.com/fredmarques/image/upload/v1734056496/LogoSweetHome_tzwyjv.png"
                            alt="logo" width="50px" />
                    </RouterLink>
                </div>
                <RouterLink to="/ViewImovelComprar" class="Nav__Li">Comprar</RouterLink>
                <RouterLink to="/ViewImovelAlugar" class="Nav__Li">Alugar</RouterLink>
                <RouterLink to="/Contato" class="Nav__Li">Contato</RouterLink>
                <RouterLink to="/SobreNos" class="Nav__Li">Sobre nós</RouterLink>
            </ul>
        </nav>
    </header>
</template>

<script>
export default {
    name: 'MenusNav',
    methods: {
        handleClick() {
            this.$emit('menuClicked'); // Emitir evento para fechar o menu
        }
    }
}
</script>
<style scoped>
.Nav__ul {
    display: flex;
    /* Utiliza flexbox para organizar os itens em linha */
    align-items: center;
    /* Alinha verticalmente os itens ao centro */
    gap: 20px;
    /* Espaçamento de 20px entre os itens */
    list-style: none;
    /* Remove o estilo de lista (como marcadores) */
    margin: 0;
    /* Remove margens ao redor da lista */
    padding: 0;
    /* Remove o padding (espaçamento interno) da lista */
}

.logo {
    display: flex;
    /* Flexbox para alinhar os itens dentro da logo */
    align-items: center;
    /* Alinha verticalmente a logo com os links */
    margin-right: auto;
    /* Empurra os links para o lado direito, deixando a logo à esquerda */
}

.Nav__Li {
    color: #333;
    /* Cor do texto do link */
    display: inline-block;
    /* Exibe os itens de lista como blocos em linha */
    padding: 5px 10px;
    /* Padding interno de 5px acima/abaixo e 10px à esquerda/direita */
    position: relative;
    /* Necessário para posicionar o pseudo-elemento ::after */
    text-decoration: none;
    /* Remove o sublinhado padrão dos links */
}

.Nav__Li:hover {
    cursor: pointer;
    /* Muda o cursor para o estilo de ponteiro ao passar o mouse sobre o link */
}

.Nav__Li:hover::after,
.router-link-active::after {
    content: "";
    /* Cria um pseudo-elemento vazio */
    position: absolute;
    /* Posiciona o pseudo-elemento de forma absoluta */
    bottom: 0;
    /* Coloca o pseudo-elemento na parte inferior do link */
    left: 0;
    /* Alinha o pseudo-elemento à esquerda */
    width: 100%;
    /* Faz com que o pseudo-elemento tenha a mesma largura do link */
    height: 2px;
    /* Define a altura da linha inferior */
    background-color: black;
    /* Cor da linha inferior */
}

@media (max-width: 768px) {
    .Nav__ul {
        flex-direction: column;
        /* Muda a direção dos itens para coluna em telas menores */
        align-items: flex-start;
        /* Alinha os itens ao início da lista (à esquerda) */
    }
}

@media (max-width: 1280px) {
    .logo {
        display: none;
        /* Oculta a logo em resoluções menores que 1280px */
    }

    .Nav__ul {
        flex-direction: column;
        /* Muda a direção dos itens para coluna em telas menores */
    }

    .Nav__Li:hover::after {
        display: none;
        /* Remove o destaque para hover em telas menores */
    }
}
</style>
