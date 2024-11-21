<template>
  <div>
    <h1>Bem-vindo, {{ usuario.username }}!</h1>
  </div>
</template>

<script>
export default {
  name: 'UsuarioPage',
  computed: {
    usuario() {
      return this.$store.getters.getUsuario; // Acessando o usuário do Vuex Store
    }
  }
};
</script>

<style scoped>
h1 {
  color: blue;
}
</style>