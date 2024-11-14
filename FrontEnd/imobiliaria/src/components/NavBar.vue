<template>
    <nav class="NavBar">
        <MenusNav />
        <ul class="Nav__actions">
            <li class="li__Home">
                <RouterLink to="ViewImovel" class="Anunce__Bnt">Anunciar Gratis</RouterLink>
                <RouterLink to="Cadastro" class="Entry__Bnt">Cadastre-se</RouterLink>
            </li>
        </ul>
    </nav>
</template>

<script>
import MenusNav from '@/components/MenusNav.vue';

export default{
    name:'NavBar',
    components:{
        MenusNav
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
    color: black;
    font-weight: bold;
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
    background-color: #59808b;
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
    background-color: #8CB9C5;
    color: #333;
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

@media(width < 1280px){
    .NavBar{
        display: none;
    }
}
</style>