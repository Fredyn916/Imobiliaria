<template>
    <nav class="NavBar">
        <div class="InsideNavBar" :class="{ show: menuVisible }">
            <RouterLink to="/" class="Home__Bnt" @click="hideMenu">Inicio</RouterLink>
            <MenusNav @menuClicked="hideMenu" />
            <ul class="Nav__actions">
                <li class="li__Home">
                    <RouterLink to="AnunciarSeuImovel" class="Anunce__Bnt" @click="hideMenu">Anunciar Gratis</RouterLink>
                    <div v-if="usuario === null">
                        <RouterLink to="Cadastro" class="Entry__Bnt" @click="hideMenu">Cadastre-se</RouterLink>
                    </div>
                    <div v-else>
                        <RouterLink to="UsuarioPage" class="Entry__Bnt" @click="hideMenu">{{ usuario.username }}</RouterLink>
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
    color: #2C3E50;
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

.Home__Bnt {
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

.Home__Bnt:hover {
    background-color: #505050;
    color: #FFF;
}

.Entry__Bnt {
    background-color: rgb(0, 43, 82);
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
    background-color: #1A5276;
}

.Menu__icon__container {
    display: flex;
    justify-content: space-between;
    align-items: center;
    width: 100%;
}

.NavBar__icon-btn {
    display: none;
    border: none;
    background-color: transparent;
    padding: 0;
    outline: none;
    display: inline-block;
}

.NavBar__icon-btn:hover {
    cursor: pointer;
    transform: scale(1.1);
}

.Header__icon {
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
        justify-content: space-around;
        padding-inline: 2rem;
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
        display: flex;
        gap: 2rem;
        width: 100%;
    }

    .Anunce__Bnt {
        background-color: transparent;
        border: 1px solid black;
        color: black;
        padding: 0.90rem 6.5rem;
        text-align: center;
        text-decoration: none;
        font-size: 12px;
        cursor: pointer;
        border-radius: 10px;
        transition: background-color 0.3s;
    }


    .Home__Bnt {
        background-color: transparent;
        border: 1px solid black;
        color: black;
        padding: 0.90rem 8rem;
        text-align: center;
        text-decoration: none;
        font-size: 12px;
        cursor: pointer;
        border-radius: 10px;
        transition: background-color 0.3s;
    }
}
</style>