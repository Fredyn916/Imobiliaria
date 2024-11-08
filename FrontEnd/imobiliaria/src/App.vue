<script>
import MenusNav from './components/MenusNav.vue';

export default {
  name: 'App',
  components: {
    MenusNav
  }
}
</script>

<template>
  <header>
    <nav class="NavBar">
      <MenusNav />
      <ul>
        <li class="li__Home">
          <RouterLink to="/" class="Anunce__Bnt">Anunciar Gratis</RouterLink>
          <RouterLink to="/" class="Entry__Bnt">Entrar</RouterLink>
        </li>
      </ul>
    </nav>
  </header>

  <RouterView />

  <section class="all">
  </section>
</template>

<style scoped>
a{
  text-decoration: none;
}
.li__Home{
  display: flex;
  gap: 20px;
}

.Anunce__Bnt {
  background-color: transparent;
  border: none;
  color: black;
  padding: 1rem 0.5rem;
  text-align: center;
  text-decoration: none;
  margin: 2px 1px;
  cursor: pointer;
  border-radius: 4px;
  transition: background-color 0.3s;
}

.Anunce__Bnt:hover {
  background-color: #333;
  color: #FFF;
}

.Entry__Bnt {
  background-color: #3C3024;
  border: none;
  color: white; 
  padding: 1rem 2rem;
  text-align: center; 
  text-decoration: none;
  display: inline-block;
  font-size: 16px;
  margin: 2px 1px;
  cursor: pointer;
  border-radius: 4px;
  transition: background-color 0.3s;
}

.Entry__Bnt:hover {
  background-color: #605346;
}

.NavBar {
  display: flex;
  justify-content: space-around;
}

.all{
  background-color: black;
  width: 100%;
  height: 100%;
}
</style>
