<template>
  <div class="User__page">
  <div class="User__Item">
    <div class="User__img">
      <img :src="usuario.fotoDePerfilURL" alt="Foto de perfil">
    </div>
    <p>{{ usuario.nome }}</p>
    <p>{{ usuario.idade }}</p>
    <p>{{ usuario.genero }}</p>
    <p>{{ usuario.cep }}</p>
    <p>{{ usuario.rua }}</p>
    <p>{{ usuario.numero }}</p>
    <p>{{ usuario.bairro }}</p>
    <p>{{ usuario.cidade }}</p>
    <p>{{ usuario.unidadeFederativa }}</p>
    <p>{{ usuario.identificacao }}</p>
    <p>{{ usuario.tipo }}</p>
  </div>
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
.User__page{
  height: 100vh;
  width: 100%;
  display: flex;
  justify-content: center;
  padding-top: 100px;
}

.User__img img{
  width: 450px;
  height: 450px;
  border-radius: 50%;
}
</style>
