<template>
    <header>
        <nav>
            <ul class="Nav__ul">
                <div class="logo">
                    <RouterLink to="/">
                        <img src="@/Images/logo.png" alt="logo" width="20px" />
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
    gap: 20px;
}

.Nav__Li {
    color: #333;
    display: inline-block;
    padding-bottom: 2px;
    position: relative;
    text-decoration: none;
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
}

.router-link-active::after {
    content: "";
    position: absolute;
    bottom: 0;
    left: 0;
    width: 100%;
    height: 2px;
    background-color: black;
}


.logo {
    display: block;
}

@media (max-width: 768px) {
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