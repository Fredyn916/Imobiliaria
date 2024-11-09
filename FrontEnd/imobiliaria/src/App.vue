<template>
  <div>
    <header class="Nav__header">
      <nav class="NavBar">
        <MenusNav />
        <ul class="Nav__actions">
          <li class="li__Home">
            <RouterLink to="/" class="Anunce__Bnt">Anunciar Gratis</RouterLink>
            <RouterLink to="/" class="Entry__Bnt">Entrar</RouterLink>
          </li>
        </ul>
      </nav>
    </header>

    <RouterView />
    <section class="Hero__bg">
    </section>

    <section class="all">
    </section>
  </div>
</template>

<script>
import MenusNav from './components/MenusNav.vue';

export default {
  name: 'App',
  components: {
    MenusNav
  }
};
</script>

<style scoped>
a {
  text-decoration: none;
}

.Nav__header{
  margin: 0;
  padding: 0;
}

.NavBar {
  display: flex;
  justify-content: space-between;
  padding: 15px 15px;
  align-items: center;
  height: 60px;
  max-width: 100%;
  margin: 0 auto;
  width: 100%;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
}


.Nav__actions {
  display: flex;
  gap: 20px;
  list-style: none;
  padding: 0;
  margin: 0;
}

.li__Home {
  display: flex;
  gap: 20px;
}

.Anunce__Bnt {
  background-color: transparent;
  border: none;
  color: black;
  padding: 0.90rem 1.5rem;
  text-align: center;
  text-decoration: none;
  font-size: 12px;
  cursor: pointer;
  border-radius: 10px;
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
  padding: 0.90rem 1.5rem;
  text-align: center; 
  text-decoration: none;
  display: inline-block;
  font-size: 12px;
  cursor: pointer;
  border-radius: 10px;
  transition: background-color 0.3s;
}

.Entry__Bnt:hover {
  background-color: #605346;
}

.Hero__bg {
  width: 100%;
  height: 300px;
}

.all {
  background-color: black;
  width: 100%;
  height: 1000px;
}
</style>
