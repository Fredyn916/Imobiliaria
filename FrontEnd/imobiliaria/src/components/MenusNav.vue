<template>
    <header>
        <nav>
            <ul class="Nav__ul">
                <RouterLink to="/">Home</RouterLink>
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
            popupVisible: false
        };
    },
    methods: {
        showPopup() {
            this.popupVisible = true;
        },
        hidePopup() {
            this.popupVisible = false;
        }
    }
}
</script>

<style>

.Nav__ul{
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

.Nav__Li:hover{
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
    /* Posiciona abaixo do item de navegação */
    left: 50%;
    /* Centraliza horizontalmente */
    transform: translate(-50%, +20px);
    /* Ajusta a posição para centralizar */
    width: 90%;
    height: 200px;
    background-color: white;
    border: 1px solid black;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.5);
    z-index: 1000;
    padding: 20px;
    text-align: center;
}
</style>