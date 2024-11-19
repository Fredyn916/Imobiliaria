<template>
    <header>
        <nav>
            <ul class="Nav__ul">
                <div class="logo">
                    <RouterLink to="/"><img src="@/Images/logo.png" alt="logo" width="20px"></RouterLink>
                </div>
                <li class="Nav__Li" @mouseover="showPopup" @mouseleave="hidePopup">Comprar</li>
                <li class="Nav__Li" @mouseover="showPopup" @mouseleave="hidePopup">Alugar</li>
                <li class="Nav__Li">Imovel Novo</li>
                <li class="Nav__Li">Buscar Imobiliarias</li>
            </ul>
        </nav>
    </header>

    <div v-if="popupVisible" class="Popup">
        <!-- Adicione os itens que você quiser aqui dentro -->
        <p>Item 1</p>
        <p>Item 2</p>
    </div>
</template>

<script>
export default {
    name: 'MenusNav',
    data() {
        return {
            popupVisible: false,
            windowWidth: window.innerWidth // Adicionando a largura da janela
        };
    },
    methods: {
        // Verificar se a largura da tela é maior que 1280px antes de mostrar o popup
        showPopup() {
            if (this.windowWidth >= 1280) {
                this.popupVisible = true;
            }
        },
        hidePopup() {
            this.popupVisible = false;
        },
        handleResize() {
            // Atualiza a largura da tela e esconde o popup caso a largura seja menor que 1280px
            this.windowWidth = window.innerWidth;
            if (this.windowWidth < 1280) {
                this.popupVisible = false; // Esconde o popup se a largura for menor que 1280px
            }
        }
    },
    mounted() {
        // Adiciona o listener de resize
        window.addEventListener('resize', this.handleResize);
    },
    beforeDestroy() {
        // Remove o listener de resize ao destruir o componente
        window.removeEventListener('resize', this.handleResize);
    }
}
</script>

<style scoped>
.Nav__ul {
    display: flex;
    gap: 20px;
}

.Nav__Li {
    color: #333;
    display: inline-block;
    padding-bottom: 2px;
    position: relative;
    gap: 20px;
}

.Nav__Li:hover {
    cursor: pointer;
}

.Nav__Li:hover::after {
    content: "";
    position: absolute;
    bottom: 0;
    left: 0;
    width: 100%;
    height: 2px;
    background-color: black;
    cursor: pointer;
}

.Popup {
    position: absolute;
    top: 5%;
    left: 50%;
    transform: translate(-50%, +20px);
    width: 90%;
    height: 200px;
    background-color: white;
    border: 1px solid black;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.5);
    z-index: 1000;
    padding: 20px;
    text-align: center;
}

.logo {
    display: block;
}

@media (min-width: 200px) and (max-width: 600px) {
    .Popup {
        display: none;
    }

    .Nav__ul {
        display: flex;
        flex-direction: column;
        gap: 20px;
    }
}

@media (max-width: 1280px) {
    .logo {
        display: none;
    }

    .Nav__ul {
        display: flex;
        flex-direction: column;
        gap: 20px;
    }

    .Nav__Li:hover::after {
        display: none;
    }
}
</style>