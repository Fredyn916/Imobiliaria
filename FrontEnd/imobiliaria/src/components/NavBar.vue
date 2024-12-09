<template>
    <nav class="NavBar">
        <MenusNav />
        <ul class="Nav__actions">
            <li class="li__Home">
                <RouterLink to="BeforeAddImovel" class="Anunce__Bnt">Anunciar Gratis</RouterLink>
                <div v-if="!usuario">
                    <RouterLink to="Cadastro" class="Entry__Bnt">Cadastre-se</RouterLink>
                </div>
                <div v-else>
                    <RouterLink to="UsuarioPage" class="Entry__Bnt">{{ usuario.username }}</RouterLink>
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
    justify-content: space-between;
    padding-inline: 12rem;
    align-items: center;
    height: 60px;
    max-width: 100%;
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
    font-weight: bold;
    padding: 0.90rem 1.5rem;
    text-align: center;
    text-decoration: none;
    font-size: 12px;
    cursor: pointer;
    border-radius: 10px;
    transition: 0.2s;
}

.Anunce__Bnt:hover {
    background-color: #ededed;
    color: #000;
    transform: scale(1.05);
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
    transition: .3s;
}

.Entry__Bnt:hover {
    background-color: #1A5276;
    transform: scale(1.05);
    font-weight: bold;
}



@media (min-width: 200px) and (max-width: 600px) {
    .NavBar {
        display: flex;
        justify-content: space-between;
        flex-direction: column;
        padding-inline: 12rem;
        align-items: center;
        height: 400px;
        max-width: 100%;
        margin: 0 auto;
        width: 100%;
        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
    }
}

@media(width < 1280px) {
    .NavBar {
        display: none;
    }
}
</style>