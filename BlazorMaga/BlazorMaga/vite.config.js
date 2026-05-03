import { defineConfig } from 'vite';

export default defineConfig({
  build: {
    lib: {
      entry: 'src/editor.js',
      name: 'EditorBundle',
      fileName: 'editor'
    },
    outDir: 'wwwroot/js',
    rollupOptions: {
      output: {
        format: 'iife' // щоб був один глобальний файл
      }
    }
  }
});
