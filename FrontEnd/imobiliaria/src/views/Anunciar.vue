<template>
    <div>
        <select name="" id="">
            <option value="Apartamento" disabled>Apartamento</option>
            <option value="Apartamento">Apartamento</option>
            <option value="Lote">Lote</option>
            <option value="Casa">Casa</option>
            <option value="Comercial">Comercial</option>
            <option value="Rural">Rural</option>
            <option value="Terreno">Terreno</option>
        </select>
    </div>

</template>

<script scoped>
import NavBar from '@/components/NavBar.vue';
import MobileNavBar from '@/components/MobileNavBar.vue';
export default {
    name: 'Anunciar',
    components: {
        MobileNavBar,
        NavBar
    }
}
</script>

<style></style>