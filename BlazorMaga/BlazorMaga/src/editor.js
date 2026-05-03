import Quill from 'quill';
import TableUp, {
  defaultCustomSelect,
  TableAlign,
  TableMenuContextmenu,
  TableResizeLine,
  TableResizeScale,
  TableSelection,
  TableVirtualScrollbar
} from 'quill-table-up';

const Font = Quill.import('formats/font');
Font.whitelist = [
  'montserrat',
  'philosopher',
  'arial',
  'times-new-roman',
  'courier',
  'georgia'
];

import 'quill/dist/quill.snow.css';
import 'quill-table-up/index.css';
import 'quill-table-up/table-creator.css';
import './editor-fonts.css';

const BlockEmbed = Quill.import('blots/block/embed');
const AlignStyle = Quill.import('attributors/style/align');
const Icons = Quill.import('ui/icons');

const tableTranslations = {
    'InsertTop': 'Додати рядок зверху',
    'InsertBottom': 'Додати рядок знизу',
    'InsertLeft': 'Додати стовпець зліва',
    'InsertRight': 'Додати стовпець справа',
    'MergeCell': 'Об’єднати клітинки',
    'SplitCell': 'Розділити клітинку',
    'DeleteRow': 'Видалити рядок',
    'DeleteColumn': 'Видалити стовпець',
    'DeleteTable': 'Видалити таблицю',
    'BackgroundColor': 'Колір фону',
    'BorderColor': 'Колір меж',
    'transparent': 'Прозорий',
    'clear': 'Очистити',
    'custom': 'Власний колір',
    'fullCheckboxText': 'Для всієї таблиці',
};

AlignStyle.whitelist = ['left', 'center', 'right', 'justify'];
Icons['align']['left'] = Icons['align'][''];

const originalAdd = AlignStyle.add;
AlignStyle.add = function (node, value) {
    if (value === 'left') {
        node.style.textAlign = 'left';
        return true;
    }
    return originalAdd.call(this, node, value);
};

class VideoBlot extends BlockEmbed {
    static blotName = 'video';
    static tagName = 'video';

    static create(value) {
        let node = super.create();
        node.setAttribute('src', value);
        node.setAttribute('controls', true);
        node.style.width = "100%";
        node.style.height = "auto";
        return node;
    }
}

Quill.register(VideoBlot);
Quill.register(AlignStyle, true);
Quill.register(Font, true);
Quill.register({ [`modules/${TableUp.moduleName}`]: TableUp }, true);

window.initQuillWithTableUp = function(selector, dotNetHelper) {
  const quill = new Quill(selector, {
    theme: 'snow',
    modules: {
      toolbar: [
            ['bold', 'italic', 'underline', 'strike'], // форматування
            [{ 'header': [1, 2, 3, 4, 5, 6, false] }], // заголовки
			[{ 'font': Font.whitelist }, // шрифти
			{ 'size': [] }], // розміри
            [{ 'list': 'ordered'}, { 'list': 'bullet' }], // списки
            [{ 'indent': '-1' }, { 'indent': '+1' }], // відступи
            [{ 'align': ['left', 'center', 'right', 'justify'] }], // вирівнювання
            [{ 'color': [] }, { 'background': [] }], // кольори
			['blockquote', 'code-block'], // цитати і код
            ['link', 'image', 'video'], // медіа
            ['formula'], // формули
            ['clean'], // очистка форматування
            [{ [TableUp.toolName]: [] }] // таблиці
      ],
      [TableUp.moduleName]: {
          customSelect: defaultCustomSelect,
          texts: (key) => {
              console.log("TableUp key requested:", key); // Це допоможе відлагодити
              return tableTranslations[key] || key;
          },
        modules: [
          { module: TableVirtualScrollbar },
          { module: TableAlign },
          { module: TableResizeLine },
          { module: TableResizeScale },
          { module: TableSelection },
          { module: TableMenuContextmenu },
        ],
      },
    },
  });

  quill.on('text-change', () => {
    dotNetHelper.invokeMethodAsync("OnContentChanged", quill.root.innerHTML);
  });

    window._quillInstance = quill;

    const toolbar = quill.getModule('toolbar');
    toolbar.addHandler('image', () => {
        dotNetHelper.invokeMethodAsync("ShowGalleryFromQuill", "image");
    });

    toolbar.addHandler('video', () => {
        dotNetHelper.invokeMethodAsync("ShowGalleryFromQuill", "video");
    });

    window.insertMediaToQuill = function (url) {
        const quill = window._quillInstance;
        const range = quill.getSelection(true);

        if (url.match(/\.(jpg|jpeg|png|gif)$/i)) {
            quill.insertEmbed(range.index, 'image', url);
        } else if (url.match(/\.(mp4|webm|ogg)$/i)) {
            quill.insertEmbed(range.index, 'video', url); // тепер це <video>
        }
    };

    window.setQuillContent = function (html) {
        const quill = window._quillInstance;
        if (quill) {
            quill.root.innerHTML = html;
        }
    };

};
