<template>
  <div class="hideNavBar">
    <NavBar />
  </div>
  <div class="ShowNavBar">
    <MobileNavBar />
  </div>
  <div class="login-container">
    <div class="form-container">
      <h1>Faça Login</h1>
      <form @submit="loginUsuario" class="login-form">
        <div class="form-group">
          <label for="username">Username :</label>
          <input type="text" id="username" v-model="username" required />
        </div>
        <div class="form-group">
          <label for="senha">Senha :</label>
          <input type="password" id="senha" v-model="senha" required />
        </div>
        <button type="submit" class="login-btn">Login</button>
      </form>
      <div v-if="message" :class="['message', message === 'Sucesso.' ? 'success' : 'error']">{{ message }}</div>
    </div>
  </div>
</template>

<script>
import NavBar from '@/components/NavBar.vue';
import MobileNavBar from '@/components/MobileNavBar.vue';
export default {
  name: 'Login',
  components:{
    NavBar,
    MobileNavBar
  },
  data() {
    return {
      username: '',
      senha: '',
      tipoUsuario: 'Cliente', // Valor padrão
      message: ''
    };
  },
  methods: {
    async loginUsuario(e) {
      e.preventDefault();
      this.message = ''; // Limpa a mensagem antes de uma nova tentativa

      const data = {
        username: this.username,
        senha: this.senha
      };

      const dataJson = JSON.stringify(data);

      try {
        const req = await fetch('https://localhost:7248/Usuario/fazer-login', {
          method: 'POST',
          headers: { 'Content-Type': 'application/json' },
          body: dataJson,
        });

        if (!req.ok) {
          throw new Error('Erro no login');
        }

        const usuario = await req.json();
        console.log('Resposta da API:', usuario);

        if (data.username === usuario.username) {
          this.message = 'Sucesso.';

          // Redireciona com base no tipo de usuário
          if (usuario.tipoUsuario === "Cliente") {
            this.$router.push('/InitialPageClientes');
          } else if (usuario.tipoUsuario === "Admin") {
            this.$router.push('/InitialPage'); // Redireciona para a rota para Administrador
          } else {
            this.message = 'Tipo de usuário desconhecido.';
          }

          this.username = '';
          this.senha = '';

        } else {
          this.message = 'Erro nas credenciais.';
        }

      } catch (error) {
        this.message = 'Erro ao conectar à API.';
      }
    }
  }
};
</script>

<style scoped>
@media(width < 1280px) {

  .hideNavBar {
    display: none;
  }

  .ShowNavBar {
    display: block;
  }

}

@media(width > 1280px) {

  .hideNavBar {
    display: block;
  }

  .ShowNavBar {
    display: none;
  }

}

.message {
  margin-top: 15px;
  font-size: 16px;
}

.success {
  color: green;
}

.error {
  color: red;
}
</style>