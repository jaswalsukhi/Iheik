using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Iheik.Extensions
{
    /// <summary>
    /// Class to support select list in UI operations.
    /// </summary>
    public static class SelectListExtension
    {
        /// <summary>
        /// Convert Enumerable list to a select list, with default select option.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <param name="text">The text.</param>
        /// <param name="value">The value.</param>
        /// <param name="defaultOption">The default option.</param>
        /// <returns>SelectListItem list for dropdowns.</returns>
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> text, Func<T, string> value, string defaultOption)
        {
            var items = enumerable.Select(f => new SelectListItem
            {
                Text = text(f),
                Value = value(f)
            }
                                          ).ToList();

            items.Insert(0, new SelectListItem()
            {
                Text = defaultOption,
                Value = ""
            }
                         );

            return items;
        }

        /// <summary>
        /// Convert Enumerable list to a select list, with selected item set and default select option.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <param name="text">The text.</param>
        /// <param name="value">The value.</param>
        /// <param name="selected">The selected.</param>
        /// <param name="defaultOption">The default option.</param>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> text, Func<T, string> value, string selected, string defaultOption)
        {
            var items = enumerable.Select(f => new SelectListItem
            {
                Selected = (text(f) == selected),
                Text = text(f),
                Value = value(f)
            }
                                          ).ToList();

            items.Insert(0, new SelectListItem()
            {
                Text = defaultOption,
                Value = ""
            }
                         );

            return items;
        }

        /// <summary>
        /// Convert Enumerable list to a select list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <param name="text">The text.</param>
        /// <param name="value">The value.</param>
        /// <returns>SelectListItem list for dropdowns.</returns>
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> text, Func<T, string> value)
        {
            var items = enumerable.Select(f => new SelectListItem
            {
                Text = text(f),
                Value = value(f)
            }).ToList();

            return items;
        }


        /// <summary>
        /// This helper is created to fill in customer entity list.
        /// </summary>
        /// <param name="userEntityList">The user entity list.</param>
        /// <param name="showAll">if set to <c>true</c> [show all].</param>
        /// <param name="prompt">if set to <c>true</c> [prompt].</param>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> ToCustomerEntityList(this IEnumerable<UserEntityPoco> userEntityList, bool showAll, bool prompt)
        {
            IEnumerable<SelectListItem> list = null;
            if (userEntityList.Any())
            {
                string selectedValue = string.Empty;

                // Add the "ALL" option to the division selector 
                string allDivisionsOption = string.Empty;

                //Add Prompt option
                string promptOption = string.Empty;

                if (showAll)
                {
                    allDivisionsOption = "ALL Divisions";
                }
                if (prompt)
                {
                    promptOption = "Please select a division";
                }
                // load the select list and set the selected item if available 
                list = BuildSelectList(userEntityList, a => a.CustomerEntityCode, a => a.CustomerEntityId.ToString(), selectedValue, allDivisionsOption, promptOption);

            }
            return list;

        }

        /// <summary>
        /// Builds the select list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <param name="text">The text.</param>
        /// <param name="value">The value.</param>
        /// <param name="selected">The selected.</param>
        /// <param name="allDivisionsOption">All divisions option.</param>
        /// <param name="promptOption">The prompt option.</param>
        /// <returns></returns>
        private static IEnumerable<SelectListItem> BuildSelectList<T>(IEnumerable<T> enumerable, Func<T, string> text, Func<T, string> value, string selected, string allDivisionsOption = "", string promptOption = "")
        {
            var items = enumerable.Select(f => new SelectListItem
            {
                Selected = (text(f) == selected),
                Text = text(f),
                Value = value(f)
            }
                                          ).ToList();

            // add "ALL" when required
            if (!string.IsNullOrEmpty(allDivisionsOption))
            {
                items.Insert(0, new SelectListItem()
                {
                    Text = allDivisionsOption,
                    Value = "0"
                }
                    );
            }
            // add "ALL" when required
            if (!string.IsNullOrEmpty(promptOption))
            {
                items.Insert(0, new SelectListItem()
                {
                    Text = promptOption,
                    Value = "-1"
                }
                    );
            }

            return items;
        }
    }
}
