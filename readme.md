# Требования, правила, бизнес-логика

## Роли в системе

В проекте используется две роли, которые регламентируют доступ к функционалу.
`Administrator` - (главная роль) пользователь, у которого есть эта роль, может выполнять все операции с любыми сущностями).
`User` - пользоватеть, у которого есть эта роль может добавлять обзоры к товарам.

Незарегистрированные пользователи работают с системой в режиме "readonly".

## Сущность "Category" (Категория)

Сущность `Category` содержит общею информация о постах (`Entry`) хранящихся в ней.

# Поля

* [x] `Name` должно быть не менее 5 и не более 50 символов.
* [x] `Description` должно быть не более 1024 символов, но может быть пустым.
* [x] `Parent` родительская категория
* [x] `Visible` можно включить/выключить (скрыть/показать для всеобщего просмотра).

# Требования

* [] При выключении видимости все дочерние категории и посты в них должны быть скрыты от просмотра
* [] При получении всех категорий `GetAll()` администратор должен получать и скрытые категории тоже
* [] Просмотр всех каталогов должно использоваться разбиение на страницы (paging)

# API должна содержать методы CRUD для управления сущностью `Category`:
* [] `GetPaged(int pageIndex, int pageSize)`
* [] `GetAll()`
* [] `Create(CategoryViewModel model)`
* [] `GetById(Guid id)`
* [] `Update(CategoryUpdateViewModel)`
* [] `Delete(Guid id)`

## Сущность "Entry"

# Поля

* [x] `Title` должно быть не менее 5 и не более 50 символов.
* [x] `Content` не может быть пустым.
* [x] `Visible` можно включить/выключить (скрыть/показать для всеобщего просмотра).

# Требования

* [ ] Должна быть возможность добавления изображений в тело поста
* [ ] При получении всех категорий `GetAll()` и `GetPaged(int pageIndex, int pageSize)` администратор должен получать и скрытые посты тоже
* [ ] При выключении видимсоти комменатрии к посту тоже должны быть скрыты
* [ ] Просмотр всех обзоров должны использоваться разбиение на страницы (paging)

# API должна содержать методы CRUD для управления сущностью `Entry`:
* [ ] `GetPaged(int pageIndex, int pageSize)`
* [ ] `GetAll()` (глупый метод)
* [ ] `Create(EntryCreateViewModel model)` Get
* [ ] `Create(EntryCreateViewModel model)` Post
* [ ] `GetById(Guid id)`
* [ ] `Update(EntryUpdateViewModel)`Get
* [ ] `Update(EntryUpdateViewModel)`Put
* [ ] `Delete(Guid id)`

## Сущность "Review"
* [x] `UserName` должно быть не менее 5 и не более 128 символов
* [x] `Content` должно быть не более 2048 символов, не может быть пустым
* [x] `Parent` родительский комментарий
* [x] `EntryId` обязательно при создании нового обзора (комментария)

# Требования

* [ ] Посмотреть все комментарии к посту можно лишь только администратору.
* [ ] Просмотр всех обзоров должны использоваться разбиение на страницы (paging)

# API должна содержать методы CRUD для управления сущностью `Review`:
* [ ] `Create(ReviewCreateViewModel model)` Get
* [ ] `Create(ReviewCreateViewModel model)` Post
* [ ] `GetById(Guid id)`
* [ ] `Delete(Guid id)`
* [ ] `Update(Guid id)` Get
* [ ] `Update(ReviewUpdateViewModel model)` Post
* [ ] `GetLastReviews(int count)`
* [ ] `GetPaged(int pageIndex, int pageSize)`
* [ ] `GetAll(Guid productId)`

## Общие требования для сущности Review

* [ ] Товар может иметь несколько отзывов или не иметь вообще.
* [ ] Отзыв может оставить только зарегистрированный пользователь ролью `User`
* [ ] Отзыв должен содержать следующие обязательные свойства: `Id`, `Content`, `Rating`, `UserName`
* [ ] Список последних 10 отзывов может быть также запрошен на UI (см. `GetLastReview(int count)`).

## Требования для роли Администратор

* [ ] Администратор должен иметь возможность удалить любой комментарий
* [ ] Администратор должен иметь возможность удалять пост
* [ ] Администратор должен иметь возможность удалять пользователей
* [ ] Администратор должен иметь возможность создавать категории

## Требования для роли Пользователь

* [ ] Пользователь может создать пост в любой категории 
* [ ] Пользователь может добавить сколько угодно комментариев к любому посту
* [ ] Пользователь может удалить свой и только свой комментарий или пост
* [ ] Пользователь может изменить рейтинг своего отзыва и текст содержания

## Диаграмма классов

``` mermaid
classDiagram
	direction RL
	Product "*" <-- "1" Category
	Review "*" <-- "1" Product
	Auditable <|-- Identity
	Category <|-- Identity
	Entry <|-- Auditable
	Review <|-- Auditable

```

``` mermaid
---
title: Сущность Category
---
classDiagram
class Category {
	+string Name
	+string Description
    +Category Parent
	+List~Entry~
	bool Visible
}
```

``` mermaid
---
title: Сущность Entry
---
classDiagram
class Entry {
	+string Name
	+string Content
	Guid CategoryId
	+List~Review~
	bool Visible
}
```

``` mermaid
---
title: Сущность Review
---
classDiagram
class Review {
	string Content
	string User
	int Rating
	Guid Entry
	Review Parent
	bool Visible
}
```

``` mermaid
---
title: Сущность Identity
---
classDiagram
class Identity{
	<<Abstract>>
	+Guid Id
}
```

``` mermaid
---
title: Сущность Auditable
---
classDiagram
class Auditable{
	<<Abstract>>
	DateTime CreatedAt
	string CreatedBy
	DateTime? UpdatedAt
	string? UpdatedBy
}
```