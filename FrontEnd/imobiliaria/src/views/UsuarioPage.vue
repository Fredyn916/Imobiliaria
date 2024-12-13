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
    'usuario.identificacao': function (newVal) {
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
/* Estilos principais para a página de usuário */
.User__page {
  height: 100vh;
  /* Define a altura da página como 100% da altura da janela de visualização */
  width: 100%;
  /* A largura da página ocupa 100% da largura da janela de visualização */
  display: flex;
  /* Utiliza o layout flexbox */
  justify-content: flex-start;
  /* Alinha os itens flexíveis no início da linha horizontal */
  align-items: flex-start;
  /* Alinha os itens flexíveis no início da linha vertical */
  padding-top: 20px;
  /* Adiciona um padding de 20px na parte superior */
  background-color: #f8f9fa;
  /* Define o fundo da página como um tom de cinza claro */
  /* Fundo claro */
}

/* Estilos para o container de botões */
.Button__FLex {
  width: 30%;
  /* Define a largura do container como 30% da largura da página */
  height: 100%;
  /* A altura ocupa 100% da altura do container pai */
  display: flex;
  /* Utiliza o layout flexbox */
  flex-direction: column;
  /* Organiza os itens em uma coluna */
  align-items: flex-start;
  /* Alinha os itens no início da linha horizontal */
  padding: 10px;
  /* Adiciona padding de 10px ao redor do conteúdo */
}

/* Estilos para o container de botões dentro do flexbox */
.Button__container {
  display: flex;
  /* Utiliza o layout flexbox */
  flex-direction: column;
  /* Organiza os itens em uma coluna */
  width: 100%;
  /* O container ocupa 100% da largura disponível */
}

/* Estilos para os botões dentro da página */
.select__step__btn {
  margin: 5px;
  /* Adiciona uma margem de 5px ao redor do botão */
  padding: 10px 20px;
  /* Adiciona padding de 10px na parte superior e inferior e 20px nas laterais */
  cursor: pointer;
  /* Muda o cursor para uma mão ao passar sobre o botão */
  background-color: rgb(0, 43, 82);
  /* Define o fundo do botão como um tom de azul escuro */
  color: white;
  /* Define a cor do texto do botão como branca */
  border: none;
  /* Remove a borda do botão */
  border-radius: 5px;
  /* Aplica bordas arredondadas com raio de 5px */
  font-size: 16px;
  /* Define o tamanho da fonte como 16px */
  transition: background-color 0.3s;
  /* Adiciona uma transição suave de 0.3 segundos para a cor de fundo */
}

/* Estilos para o botão quando o mouse passa sobre ele */
.select__step__btn:hover {
  background-color: #1A5276;
  /* Muda a cor do fundo para um tom de azul mais claro ao passar o mouse */
}

/* Estilos para o container dos itens */
.Itens__FLex {
  width: 70%;
  /* Define a largura do container como 70% da largura da página */
  height: 100%;
  /* A altura ocupa 100% da altura do container pai */
  padding: 20px;
  /* Adiciona padding de 20px ao redor do conteúdo */
}

/* Estilos para cada item de usuário */
.User__Item {
  display: flex;
  /* Utiliza o layout flexbox */
  flex-direction: row;
  /* Organiza os itens em linha */
  gap: 20px;
  /* Define um espaço de 20px entre os itens */
  align-items: flex-start;
  /* Alinha os itens no início da linha vertical */
  padding: 20px;
  /* Adiciona padding de 20px ao redor do conteúdo */
  background-color: #ffffff;
  /* Define o fundo como branco */
  border-radius: 10px;
  /* Aplica bordas arredondadas com raio de 10px */
  box-shadow: rgba(0, 0, 0, 0.1) 0px 4px 12px;
  /* Adiciona uma sombra sutil ao redor do item */
  width: 100%;
  /* O item ocupa 100% da largura disponível */
  box-sizing: border-box;
  /* Garante que padding e borda sejam incluídos nas dimensões do item */
}

/* Estilos para a imagem do usuário */
.User__img {
  width: 100%;
  /* A largura é 100% do espaço disponível */
  max-width: 200px;
  /* Define o tamanho máximo da imagem como 200px */
  height: auto;
  /* A altura é proporcional à largura */
  display: flex;
  /* Utiliza o layout flexbox */
  justify-content: center;
  /* Centraliza a imagem horizontalmente */
  align-items: center;
  /* Centraliza a imagem verticalmente */
}

/* Estilos para a tag <img> dentro do contêiner da imagem */
.User__img img {
  width: 100%;
  /* A imagem ocupa 100% da largura do contêiner */
  height: auto;
  /* A altura é proporcional à largura da imagem */
  border-radius: 10px;
  /* Aplica bordas arredondadas com raio de 10px */
  object-fit: cover;
  /* Garante que a imagem se ajuste ao contêiner sem distorção */
}

/* Estilos para os detalhes do usuário */
.User__details {
  display: flex;
  /* Utiliza o layout flexbox */
  flex-direction: column;
  /* Organiza os itens em uma coluna */
  gap: 5px;
  /* Define um espaço de 5px entre os itens */
  flex-grow: 1;
  /* Permite que a seção cresça para ocupar o espaço restante */
  padding: 0 10px;
  /* Adiciona padding de 10px à esquerda e à direita */
}

/* Estilos para os parágrafos dentro da seção de detalhes do usuário */
.User__details p {
  font-size: 16px;
  /* Define o tamanho da fonte como 16px */
  margin: 0;
  /* Remove a margem ao redor do parágrafo */
}

/* Estilos para cada passo */
.step {
  margin: 20px;
  /* Adiciona uma margem de 20px ao redor do passo */
  padding: 20px;
  /* Adiciona padding de 20px ao redor do conteúdo do passo */
  box-shadow: rgba(0, 0, 0, 0.2) -2px 4px 15px 0px;
  /* Adiciona uma sombra suave ao redor do passo */
  border-radius: 5px;
  /* Aplica bordas arredondadas com raio de 5px */
  width: 100%;
  /* O passo ocupa 100% da largura disponível */
  text-align: left;
  /* Alinha o texto à esquerda */
  background-color: #fff;
  /* Define o fundo como branco */
  /* Fundo dos passos */
}

/* Estilos adicionais para formulários */
form {
  display: flex;
  /* Utiliza o layout flexbox */
  flex-direction: column;
  /* Organiza os itens em uma coluna */
  gap: 10px;
  /* Define um espaço de 10px entre os itens */
}

/* Estilos para os rótulos dos campos de formulário */
label {
  font-size: 14px;
  /* Define o tamanho da fonte como 14px */
  color: #333;
  /* Define a cor do texto como um tom de cinza escuro */
}

/* Estilos para campos de texto e senha */
input[type="text"],
input[type="password"] {
  padding: 10px;
  /* Adiciona padding de 10px ao redor do campo */
  border: 1px solid #ccc;
  /* Define uma borda de 1px com cor cinza claro */
  border-radius: 5px;
  /* Aplica bordas arredondadas com raio de 5px */
  font-size: 14px;
  /* Define o tamanho da fonte como 14px */
}

/* Estilos para o botão de envio do formulário */
button[type="submit"] {
  padding: 10px 20px;
  /* Adiciona padding de 10px na parte superior e inferior e 20px nas laterais */
  background-color: rgb(0, 43, 82);
  /* Define o fundo do botão como azul escuro */
  color: white;
  /* Define a cor do texto como branca */
  border: none;
  /* Remove a borda do botão */
  border-radius: 5px;
  /* Aplica bordas arredondadas com raio de 5px */
  font-size: 16px;
  /* Define o tamanho da fonte como 16px */
  cursor: pointer;
  /* Altera o cursor para uma mão ao passar sobre o botão */
  transition: background-color 0.3s;
  /* Adiciona uma transição suave de 0.3 segundos para a cor de fundo */
}

/* Estilos para o botão de envio do formulário quando o mouse passa sobre ele */
button[type="submit"]:hover {
  background-color: #1A5276;
  /* Muda a cor de fundo para um tom de azul mais claro ao passar o mouse */
}

/* Estilos responsivos para dispositivos com largura máxima de 768px */
@media (max-width: 768px) {
  .User__page {
    flex-direction: column;
    /* Organiza a página em uma coluna */
    align-items: center;
    /* Centraliza os itens verticalmente */
    padding: 10px;
    /* Adiciona padding de 10px ao redor da página */
  }

  .Button__FLex {
    width: 100%;
    /* A largura do container de botões ocupa 100% */
    flex-direction: row;
    /* Organiza os botões em linha */
    flex-wrap: wrap;
    /* Permite que os botões se envolvam para a linha seguinte se necessário */
    justify-content: center;
    /* Centraliza os botões horizontalmente */
    padding: 5px;
    /* Adiciona padding de 5px ao redor */
  }

  .Button__container {
    width: 100%;
    /* A largura do container de botões ocupa 100% */
    flex-direction: row;
    /* Organiza os botões em linha */
    justify-content: center;
    /* Centraliza os botões horizontalmente */
    gap: 10px;
    /* Define um espaço de 10px entre os botões */
  }

  .select__step__btn {
    flex: 1;
    /* Permite que os botões se expandam para ocupar espaço igual */
    margin: 5px 0;
    /* Adiciona uma margem de 5px na parte superior e inferior */
    padding: 10px;
    /* Adiciona padding de 10px ao redor do botão */
    font-size: 14px;
    /* Define o tamanho da fonte como 14px */
  }

  .Itens__FLex {
    width: 100%;
    /* A largura do container de itens ocupa 100% */
    padding: 10px;
    /* Adiciona padding de 10px ao redor do conteúdo */
  }

  .User__Item {
    flex-direction: column;
    /* Organiza os itens em uma coluna */
    align-items: center;
    /* Centraliza os itens na linha horizontal */
  }

  .User__img {
    max-width: 100px;
    /* Define o tamanho máximo da imagem como 100px */
  }

  .User__details {
    width: 100%;
    /* A largura dos detalhes ocupa 100% */
    align-items: center;
    /* Centraliza os itens na linha horizontal */
    padding: 0;
    /* Remove o padding */
  }

  .User__details p {
    text-align: center;
    /* Alinha o texto dos parágrafos ao centro */
  }

  .step {
    margin: 10px;
    /* Adiciona uma margem de 10px ao redor do passo */
    padding: 10px;
    /* Adiciona padding de 10px ao redor do passo */
  }

  form {
    align-items: center;
    /* Centraliza os itens do formulário */
  }

  button[type="submit"] {
    width: 100%;
    /* O botão ocupa 100% da largura */
  }
}

/* Estilos responsivos para dispositivos com largura máxima de 480px */
@media (max-width: 480px) {
  .select__step__btn {
    font-size: 12px;
    /* Define o tamanho da fonte como 12px */
    padding: 8px;
    /* Adiciona padding de 8px ao redor do botão */
  }

  .User__img {
    max-width: 80px;
    /* Define o tamanho máximo da imagem como 80px */
  }

  .User__details p {
    font-size: 14px;
    /* Define o tamanho da fonte como 14px */
  }

  .step {
    padding: 8px;
    /* Adiciona padding de 8px ao redor do passo */
  }
}
</style>
