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
  mounted() {
    this.updateNavbarVisibility();
    window.addEventListener("resize", this.updateNavbarVisibility);
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
  font-family: Arial, sans-serif;
}
</style>
