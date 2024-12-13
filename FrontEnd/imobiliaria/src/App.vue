<template>
  <div>
    <header class="Nav__header">
      <NavBar v-show="!isMobile" />
      <MobileNavBar v-show="isMobile" />
    </header>
    <RouterView />
    <Footer />
  </div>
</template>

<script>
import Footer from './components/Footer.vue';
import NavBar from './components/NavBar.vue';
import MobileNavBar from './components/MobileNavBar.vue';
import '@/assets/main.css';


export default {
  name: 'App',
  components: {
    Footer,
    NavBar,
    MobileNavBar,
  },
  data() {
    return {
      isMobile: false,
    };
  },
  async mounted() {
    this.updateNavbarVisibility();
    window.addEventListener("resize", this.updateNavbarVisibility);

    const data = {}

    const Response = await fetch('https://localhost:7082/Imovel/InicializarImoveis', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: data,
      });


      console.log(Response)
  },
  beforeUnmount() {
    window.removeEventListener("resize", this.updateNavbarVisibility);
  },
  methods: {
    updateNavbarVisibility() {
      this.isMobile = window.innerWidth < 1280;
    },
  },
};
</script>

<style>
.Nav__header {
  width: 100%;
  position: sticky;
  top: 0;
  z-index: 10;
  background-color: white;
  box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
}

body {
  margin: 0;
  font-family: "Funnel Display", sans-serif;
}
</style>
