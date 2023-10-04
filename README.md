# Templates-Project-4-Lesson

Памятка по работе с Zenject

Создание инсталлеров:
1) Создаем SceneContext, если хотим использовать биндинги локально на одной сцене
2) Создаем ProjectContext в папке Resources, если хотим использовать глобальные биндинги во всей игре
3) Создаем скрипты наследуемые от MonoInstaller и переопределяем в них метод InstallBindings

Биндинг:
1) Бинд класса: Container.Bind<класс>()
2) Бинд класса со всеми его интерфейсами: Container.BindInterfacesAndSelfTo<класс>()

3) Бинд класса по конструктору: Container.Bind<класс>().FromNew()
4) Бинд класса по конструктору с параметрами: Container.Bind<класс>().FromNew().AsSingle().WithArguments(аргументы);
5) Бинд класса по инстансу: Container.Bind<класс>().FromInstance(инстанс)

6) Бинд одной единственной сущности класса: Container.Bind<класс>().FromNew().AsSingle();
7) Бинд множества сущностей класса для каждого запроса: Container.Bind<класс>().FromNew().AsTransient();

Полезные интерфейсы:
1) IInitializable -> Имитирует метод Start()
2) ITickable -> Имитирует метод Update()
3) IDisposable -> Вызывается при уничтожении

* Если класс является монобехом, необходимо сделать свой метод Construct и добавить модификатор [Inject]
* Если хотим загрузить инстанс из папки Resuorces -> Класс экземпляр = Resources.Load<класс>(Path.Combine(папка, файл));
