<template>
  <div class="User__page">
    <!-- Botões de navegação -->
    <div class="Button__FLex">
      <div class="Button__container">
        <button type="button" class="select__step__btn" @click="step = 1">Dados</button>
        <button type="button" class="select__step__btn" @click="step = 2">Mudar Senha</button>
        <button type="button" class="select__step__btn" @click="step = 3">Mudar Username</button>
        <button type="button" class="select__step__btn" @click="step = 4">Deletar Usuario</button>
      </div>
    </div>

    <!-- Conteúdo dos passos -->
    <div class="Itens__FLex">
      <div v-if="step === 1" class="step">
        <div class="User__Item">
          <div class="User__img">
            <img :src="usuario.fotoDePerfilURL" alt="Foto de perfil">
          </div>
          <div class="User__details">
            <p><strong>Nome:</strong> {{ usuario.nome }}</p>
            <p><strong>Idade:</strong> {{ usuario.idade }}</p>
            <p><strong>Gênero:</strong> {{ usuario.genero }}</p>
            <p><strong>CEP:</strong> {{ usuario.cep }}</p>
            <p><strong>Rua:</strong> {{ usuario.rua }}</p>
            <p><strong>Número:</strong> {{ usuario.numero }}</p>
            <p><strong>Bairro:</strong> {{ usuario.bairro }}</p>
            <p><strong>Cidade:</strong> {{ usuario.cidade }}</p>
            <p><strong>Estado:</strong> {{ usuario.unidadeFederativa }}</p>
            <p><strong>CPF, CNPJ:</strong> {{ usuario.identificacao }}</p>
            <p v-if="isCpfValid !== null"><strong>CPF Válido:</strong> {{ isCpfValid ? 'Sim' : 'Não' }}</p>
            <p v-if="isCnpjValid !== null"><strong>CNPJ Válido:</strong> {{ isCnpjValid ? 'Sim' : 'Não' }}</p>
          </div>
        </div>
      </div>
      <div v-if="step === 2" class="step">
        <form @submit.prevent="ChangePassword">
          <label for="senha">Digite a Nova Senha</label>
          <input type="password" id="senha" v-model="senha">
          <button type="submit">Enviar</button>
        </form>
      </div>
      <div v-if="step === 3" class="step">
        <form @submit.prevent="ChangeUsername">
          <label for="username">Digite o Username</label>
          <input type="text" id="username" v-model="username">
          <button type="submit">Enviar</button>
        </form>
      </div>
      <div v-if="step === 4" class="step">
        <form @submit.prevent="DeleteAccount">
          <button type="submit">Deletar o seu Usuario</button>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'UsuarioPage',
  data() {
    return {
      step: 1,
      senha: '',
      username: '',
      isCpfValid: null,
      isCnpjValid: null,
    }
  },
  computed: {
    usuario() {
      return this.$store.getters.getUsuario; // Acessando os dados do usuário no Vuex Store
    }
  },
  watch: {
    'usuario.identificacao': function(newVal) {
      this.isCpfValid = this.isValidCpf(newVal);
      this.isCnpjValid = this.isValidCnpj(newVal);
    }
  },
  methods: {
    // Método para alterar a senha
    async ChangePassword() {
      const userId = this.usuario.id;

      const data = {
        id: userId,
        valor: this.senha
      }

      try {
        const response = await fetch(`https://localhost:7082/Usuario/EditarSenha`, {
          method: 'PUT',
          headers: { 'Content-Type': 'application/json' },
          body: JSON.stringify(data),
        });

        if (response.ok) {
          console.log('Senha alterada com sucesso');
        } else {
          console.log('Erro ao alterar a senha');
        }
      } catch (error) {
        console.error('Erro:', error);
      }
    },
    // Método para alterar o username
    async ChangeUsername() {
      const userId = this.usuario.id;

      const data = {
        id: userId,
        username: this.username
      }

      try {
        const response = await fetch(`https://localhost:7082/Usuario/EditarUsername`, {
          method: 'PUT',
          headers: { 'Content-Type': 'application/json' },
          body: JSON.stringify(data),
        });

        if (response.ok) {
          console.log('Username alterado com sucesso');
        } else {
          console.log('Erro ao alterar o username');
        }
      } catch (error) {
        console.error('Erro:', error);
      }
    },
    // Método para deletar a conta
    async DeleteAccount() {
      const userId = this.usuario.id;

      try {
        const response = await fetch(`https://localhost:7082/Usuario/RemoverUsuario?id=${userId}`, {
          method: 'DELETE',
          headers: { 'Content-Type': 'application/json' }
        });

        if (response.ok) {
          console.log('Conta deletada com sucesso');
        } else {
          console.log('Erro ao deletar a conta');
        }
      } catch (error) {
        console.error('Erro:', error);
      }
    },
    // Método para verificar CPF
    isValidCpf(cpf) {
      cpf = cpf.replace(/[^\d]+/g, ''); // Remover caracteres não numéricos

      if (cpf.length !== 11 || /^(\d)\1{10}$/.test(cpf)) {
        return false;
      }

      let sum = 0;
      let remainder;

      // Primeiro dígito verificador
      for (let i = 0; i < 9; i++) {
        sum += parseInt(cpf.charAt(i)) * (10 - i);
      }

      remainder = (sum * 10) % 11;
      if (remainder === 10 || remainder === 11) remainder = 0;
      if (remainder !== parseInt(cpf.charAt(9))) return false;

      sum = 0;

      // Segundo dígito verificador
      for (let i = 0; i < 10; i++) {
        sum += parseInt(cpf.charAt(i)) * (11 - i);
      }

      remainder = (sum * 10) % 11;
      if (remainder === 10 || remainder === 11) remainder = 0;
      if (remainder !== parseInt(cpf.charAt(10))) return false;

      return true;
    },
    // Método para verificar CNPJ
    isValidCnpj(cnpj) {
      cnpj = cnpj.replace(/[^\d]+/g, ''); // Remover caracteres não numéricos

      if (cnpj.length !== 14 || /^(\d)\1{13}$/.test(cnpj)) {
        return false;
      }

      let size = cnpj.length - 2;
      let numbers = cnpj.substring(0, size);
      let digits = cnpj.substring(size);
      let sum = 0;
      let pos = size - 7;

      for (let i = size; i >= 1; i--) {
        sum += parseInt(cnpj.charAt(size - i)) * pos--;
        if (pos < 2) pos = 9;
      }

      let result = sum % 11 < 2 ? 0 : 11 - sum % 11;
      if (result !== parseInt(digits.charAt(0))) return false;

      sum = 0;
      pos = size - 7;

      for (let i = size + 1; i >= 1; i--) {
        sum += parseInt(cnpj.charAt(size - i)) * pos--;
        if (pos < 2) pos = 9;
      }

      result = sum % 11 < 2 ? 0 : 11 - sum % 11;
      if (result !== parseInt(digits.charAt(1))) return false;

      return true;
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
  background-color: #f8f9fa;
  /* Fundo claro */
}

.Button__FLex {
  width: 30%;
  height: 100%;
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  padding: 10px;
}

.Button__container {
  display: flex;
  flex-direction: column;
  width: 100%;
}

.select__step__btn {
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

.select__step__btn:hover {
  background-color: #1A5276;
}

.Itens__FLex {
  width: 70%;
  height: 100%;
  padding: 20px;
}

.User__Item {
  display: flex;
  flex-direction: row;
  /* Mantém a estrutura em linha */
  gap: 20px;
  align-items: flex-start;
  padding: 20px;
  background-color: #ffffff;
  border-radius: 10px;
  box-shadow: rgba(0, 0, 0, 0.1) 0px 4px 12px;
  width: 100%;
  /* Garante que o item ocupe 100% do espaço disponível */
  box-sizing: border-box;
  /* Evita problemas de dimensionamento com padding */
}

.User__img {
  width: 100%;
  /* A largura é 100% do espaço disponível */
  max-width: 200px;
  /* Define o tamanho máximo para a imagem */
  height: auto;
  /* A altura é proporcional à largura */
  display: flex;
  justify-content: center;
  align-items: center;
}

.User__img img {
  width: 100%;
  height: auto;
  /* A altura da imagem será ajustada proporcionalmente */
  border-radius: 10px;
  object-fit: cover;
  /* Garante que a imagem se ajuste ao contêiner sem distorção */
}

.User__details {
  display: flex;
  flex-direction: column;
  gap: 5px;
  flex-grow: 1;
  /* A seção de detalhes vai crescer para ocupar o espaço restante */
  padding: 0 10px;
  /* Adiciona um pequeno padding para afastar do conteúdo */
}

.User__details p {
  font-size: 16px;
  margin: 0;
}


.step {
  margin: 20px;
  padding: 20px;
  box-shadow: rgba(0, 0, 0, 0.2) -2px 4px 15px 0px;
  border-radius: 5px;
  width: 100%;
  text-align: left;
  background-color: #fff;
  /* Fundo dos passos */
}

/* Estilos adicionais */
form {
  display: flex;
  flex-direction: column;
  gap: 10px;
}

label {
  font-size: 14px;
  color: #333;
}

input[type="text"],
input[type="password"] {
  padding: 10px;
  border: 1px solid #ccc;
  border-radius: 5px;
  font-size: 14px;
}

button[type="submit"] {
  padding: 10px 20px;
  background-color: rgb(0, 43, 82);
  color: white;
  border: none;
  border-radius: 5px;
  font-size: 16px;
  cursor: pointer;
  transition: background-color 0.3s;
}

button[type="submit"]:hover {
  background-color: #1A5276;
}

@media (max-width: 768px) {
  .User__page {
    flex-direction: column;
    align-items: center;
    padding: 10px;
  }

  .Button__FLex {
    width: 100%;
    flex-direction: row;
    flex-wrap: wrap;
    justify-content: center;
    padding: 5px;
  }

  .Button__container {
    width: 100%;
    flex-direction: row;
    justify-content: center;
    gap: 10px;
  }

  .select__step__btn {
    flex: 1;
    margin: 5px 0;
    padding: 10px;
    font-size: 14px;
  }

  .Itens__FLex {
    width: 100%;
    padding: 10px;
  }

  .User__Item {
    flex-direction: column;
    align-items: center;
  }

  .User__img {
    max-width: 100px;
  }

  .User__details {
    width: 100%;
    align-items: center;
    padding: 0;
  }

  .User__details p {
    text-align: center;
  }

  .step {
    margin: 10px;
    padding: 10px;
  }

  form {
    align-items: center;
  }

  button[type="submit"] {
    width: 100%;
  }
}

@media (max-width: 480px) {
  .select__step__btn {
    font-size: 12px;
    padding: 8px;
  }

  .User__img {
    max-width: 80px;
  }

  .User__details p {
    font-size: 14px;
  }

  .step {
    padding: 8px;
  }
}
</style>
