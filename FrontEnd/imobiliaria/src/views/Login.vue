<template>
  <form @submit="loginUsuario" class="login-form">
    <label for="username">Username :</label>
    <input type="text" id="username" v-model="username" required />
    <label for="password">Password :</label>
    <input type="text" id="password" v-model="password" required />
    <button type="submit">Login</button>
  </form>
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

      const req = await fetch('https://localhost:7082/Usuario/LogarUsuario', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: dataJson,
      });

      const usuario = await req.json();
      
      console.log('Resposta da API:', usuario);

      this.$store.dispatch('setUsuario', usuario);

      if (usuario.password === this.password) {
        this.$router.push('/UsuarioPage');
      }
    }
  }
};
</script>
