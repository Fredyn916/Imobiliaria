<template>
    <header>
        <nav>
            <ul class="Nav__ul">
                <div class="logo">
                    <RouterLink to="/">
                        <img 
                            src="https://res.cloudinary.com/fredmarques/image/upload/v1734056496/LogoSweetHome_tzwyjv.png" 
                            alt="logo" 
                            width="50px" 
                        />
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
    align-items: center; /* Alinha verticalmente os itens ao centro */
    gap: 20px;
    list-style: none;
    margin: 0;
    padding: 0;
}

.logo {
    display: flex;
    align-items: center; /* Alinha verticalmente a logo com os links */
    margin-right: auto; /* Empurra os links para o lado direito */
}

.Nav__Li {
    color: #333;
    display: inline-block;
    padding: 5px 10px;
    position: relative;
    text-decoration: none;
}

.Nav__Li:hover {
    cursor: pointer;
}

.Nav__Li:hover::after,
.router-link-active::after {
    content: "";
    position: absolute;
    bottom: 0;
    left: 0;
    width: 100%;
    height: 2px;
    background-color: black;
}

@media (max-width: 768px) {
    .Nav__ul {
        flex-direction: column; /* Transforma em uma coluna em telas menores */
        align-items: flex-start;
    }
}

@media (max-width: 1280px) {
    .logo {
        display: none; /* Oculta a logo em resoluções menores */
    }

    .Nav__ul {
        flex-direction: column;
    }

    .Nav__Li:hover::after {
        display: none; /* Remove o destaque para hover em telas menores */
    }
}
</style>
