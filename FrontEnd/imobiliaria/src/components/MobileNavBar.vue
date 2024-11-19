<template>
    <nav class="NavBar">
        <div class="InsideNavBar" :class="{ show: menuVisible }">
            <MenusNav />
            <ul class="Nav__actions">
                <li class="li__Home">
                    <RouterLink to="Anunciar" class="Anunce__Bnt">Anunciar Gratis</RouterLink>
                    <RouterLink to="Cadastro" class="Entry__Bnt">Entrar</RouterLink>
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
            menuVisible: false // Controla a visibilidade do menu
        };
    },
    methods: {
        // Alterna a visibilidade do menu
        toggleMenu() {
            this.menuVisible = !this.menuVisible;
        }
    }
}
</script>

<style scoped>
.NavBar {
    display: flex;
    justify-content: space-between;
    padding-inline: 12rem;
    align-items: center;
    height: 60px;
    margin: 0 auto;
    width: 100%;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
}

.Nav__actions {
    display: flex;
    gap: 20px;
    list-style: none;
    padding: 0;
    margin: 0;
}

.li__Home {
    display: flex;
    gap: 20px;
}

.Anunce__Bnt {
    background-color: transparent;
    border: none;
    color: black;
    padding: 0.90rem 1.5rem;
    text-align: center;
    text-decoration: none;
    font-size: 12px;
    cursor: pointer;
    border-radius: 10px;
    transition: background-color 0.3s;
}

.Anunce__Bnt:hover {
    background-color: #505050;
    color: #FFF;
}

.Entry__Bnt {
    background-color: #8CB9C5;
    border: none;
    color: white;
    padding: 0.90rem 1.5rem;
    text-align: center;
    text-decoration: none;
    display: inline-block;
    font-size: 12px;
    cursor: pointer;
    border-radius: 10px;
    transition: background-color 0.3s;
}

.Entry__Bnt:hover {
    background-color: #59808b;
}

.Menu__icon__container {
    display: flex;
    justify-content: space-between;
    /* Garante que a logo e o ícone de menu fiquem em lados opostos */
    align-items: center;
    width: 100%;
}

.NavBar__icon-btn {
    display: none;
}

.header__icon {
    width: 1.75rem;
    height: 1.75rem;
}

@media (max-width: 1280px) {
    .NavBar__icon-btn {
        display: block;
    }

    .InsideNavBar {
        display: none;
    }

    .NavBar {
        display: flex;
        justify-content: space-between;
    }

    .InsideNavBar.show {
        display: flex;
        flex-direction: column;
        position: absolute;
        text-align: center;
        align-items: center;
        justify-content: center;
        top: 60px;
        right: 0;
        width: 20%;
        height: 100vh;
        max-height: 100vh;
        background-color: #fff;
        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
        z-index: 1000;
    }

    .li__Home {
        display: flex;
        flex-direction: column;
    }

    .Nav__actions {
        display: flex;
        align-items: center;
        gap: 20px;
        list-style: none;
        padding: 0;
        margin: 0;
    }
}

@media (max-width: 768px) {
    .InsideNavBar.show {
        display: block;
    }
}
</style>