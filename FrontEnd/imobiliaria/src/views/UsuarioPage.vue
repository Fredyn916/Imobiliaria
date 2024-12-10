<template>
  <div class="User__page">
    <!-- Botões de navegação -->
    <div class="Button__FLex">
      <div class="Button__container">
        <button type="button" class="select-step-btn" @click="step = 1">Dados</button>
        <button type="button" class="select-step-btn" @click="step = 2">Mudar Senha</button>
        <button type="button" class="select-step-btn" @click="step = 3">Mudar Email</button>
        <button type="button" class="select-step-btn" @click="step = 4">Deletar Usuario</button>
      </div>
    </div>

    <!-- Conteúdo dos passos -->
    <div class="Itens__FLex">
      <div v-if="step === 1" class="step">
        <div class="User__Item">
          <div class="User__img">
            <img :src="usuario.fotoDePerfilURL" alt="Foto de perfil">
          </div>
          <p>Nome: {{ usuario.nome }}</p>
          <p>Idade: {{ usuario.idade }}</p>
          <p>Genero: {{ usuario.genero }}</p>
          <p>CEP: {{ usuario.cep }}</p>
          <p>Rua: {{ usuario.rua }}</p>
          <p>Numero: {{ usuario.numero }}</p>
          <p>Bairrro: {{ usuario.bairro }}</p>
          <p>Cidade: {{ usuario.cidade }}</p>
          <p>Estado: {{ usuario.unidadeFederativa }}</p>
          <p>CPF, CNPJ: {{ usuario.identificacao }}</p>
        </div>
      </div>
      <div v-if="step === 2" class="step">
        Mudar Senha
      </div>
      <div v-if="step === 3" class="step">
        Mudar Email
      </div>
      <div v-if="step === 4" class="step">
        Deletar Usuario
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: 'UsuarioPage',
  data() {
    return {
      step: 1 // Inicializando 'step' como número
    }
  },
  computed: {
    usuario() {
      return this.$store.getters.getUsuario; // Acessando os dados do usuário no Vuex Store
    }
  }
};
</script>

<style scoped>
.User__page {
  height: 100vh;
  width: 100%;
  display: flex;
  justify-content: flex-start;
  align-items: flex-start;
  padding-top: 20px;
}

.Button__FLex {
  width: 30%;
  /* 30% da largura para os botões */
  height: 100%;
  display: flex;
  flex-direction: column;
  /* Organizando os botões em coluna */
  align-items: flex-start;
  /* Alinhando os botões à esquerda */
  padding: 10px;
}

.Button__container {
  display: flex;
  flex-direction: column;
  /* Organizando os botões em uma coluna */
  width: 100%;
}

.select-step-btn {
  margin: 5px;
  padding: 10px 20px;
  cursor: pointer;
  background-color: rgb(0, 43, 82);
  color: white;
  border: none;
  border-radius: 5px;
  font-size: 16px;
  transition: background-color 0.3s;
}

.select-step-btn:hover {
  background-color: #1A5276;
}

.Itens__FLex {
  width: 70%;
  /* 70% da largura para o conteúdo */
  height: 100%;
  padding: 20px;
}

.User__img img {
  width: 150px;
  height: 150px;
  border-radius: 50%;
}

.User__Item {
  display: flex;
  flex-direction: column;
}

.User__Item p {
  margin: 5px 0;
  font-size: 16px;
}

.step {
  margin: 20px;
  padding: 10px;
  box-shadow: rgba(0, 0, 0, 0.2) -2px 4px 15px 0px;
  border-radius: 5px;
  width: 100%;
  text-align: left;
}
</style>
