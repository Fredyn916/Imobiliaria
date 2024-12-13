<template>
  <div class="Login__container">
    <div class="login__background">
      <form @submit="loginUsuario" class="login-form">
        <h1 class="form-title">Faça Login</h1>

        <div class="form__group">
          <label for="username">Username:</label>
          <input type="text" id="username" v-model="username" required />
        </div>

        <div class="form__group">
          <label for="password">Password:</label>
          <input type="password" id="password" v-model="password" required />
        </div>

        <button type="submit" class="submit__btn">Entrar</button>

        <div class="signup__prompt">
          <h2>Ainda não tem cadastro?</h2>
          <RouterLink to="/Cadastro" class="signup__link">Criar Conta</RouterLink>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
export default {
  name: 'Login',
  data() {
    return {
      username: '',
      password: ''
    };
  },
  methods: {
    async loginUsuario(e) {
      e.preventDefault();

      const data = {
        username: this.username,
        password: this.password
      };

      const dataJson = JSON.stringify(data);

      try {
        const req = await fetch('https://localhost:7082/Usuario/LogarUsuario', {
          method: 'POST',
          headers: { 'Content-Type': 'application/json' },
          body: dataJson,
        });

        // Verificar se a resposta é ok (status 200)
        if (!req.ok) {
          throw new Error('Login falhou, verifique suas credenciais.');
        }

        const usuario = await req.json();

        // Verificar se as credenciais são válidas
        if (usuario.username === this.username && usuario.password === this.password) {
          // Armazenar usuário no estado global (store)
          this.$store.dispatch('setUsuario', usuario);

          // Redirecionar para a página principal após login bem-sucedido
          this.$router.push('/');
        } else {
          alert('Credenciais inválidas');
        }
      } catch (error) {
        console.error(error);
        alert('Erro ao fazer login. Tente novamente mais tarde.');
      }
    }
  }
};
</script>

<style scoped>
.Login__container {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
  background-color: #f3f7f8;
  overflow: hidden;
  position: relative;
}

.login__background {
  position: relative;
  display: flex;
  justify-content: center;
  align-items: center;
  padding: 40px;
  background-color: rgba(255, 255, 255, 0.85);
  border-radius: 10px;
  box-shadow: 0 4px 30px rgba(0, 0, 0, 0.1);
  backdrop-filter: blur(10px);
  animation: slideIn 1s ease-out;
  max-width: 450px;
  width: 100%;
}

@keyframes slideIn {
  0% {
    transform: translateY(-50px);
    opacity: 0;
  }

  100% {
    transform: translateY(0);
    opacity: 1;
  }
}

.form-title {
  font-size: 2rem;
  color: #333;
  margin-bottom: 20px;
  font-family: "Funnel Display", sans-serif;
  text-align: center;
  letter-spacing: 1px;
}

.form__group {
  margin-bottom: 20px;
}

.form__group label {
  font-size: 1.1rem;
  color: #666;
  margin-bottom: 8px;
}

.form__group input {
  width: 100%;
  padding: 15px;
  border: 2px solid #ddd;
  border-radius: 8px;
  font-size: 1rem;
  background-color: #f9f9f9;
  color: #333;
  transition: all 0.3s ease;
}

.form__group input:focus {
  border-color: #1c92d2;
  background-color: #fff;
}

.submit__btn {
  width: 100%;
  padding: 12px;
  background-color: rgb(0, 43, 82);
  color: white;
  border: none;
  border-radius: 8px;
  font-size: 1.1rem;
  cursor: pointer;
  transition: background-color 0.3s ease;
}

.submit__btn:hover {
  background-color: #1A5276;
}

.signup__prompt {
  text-align: center;
  margin-top: 20px;
}

.signup__prompt h2 {
  font-size: 1.2rem;
  color: #666;
  margin-bottom: 10px;
}

.signup__link {
  font-weight: bold;
  color: rgb(0, 43, 82);
  text-decoration: none;
  font-size: 1.1rem;
  transition: color 0.3s ease;
}

.signup__link:hover {
  color: #1A5276;
}
</style>
