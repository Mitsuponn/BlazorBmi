using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBmi
{
    public class CustomValidator : ComponentBase
    {
        private ValidationMessageStore messageStore;
        [CascadingParameter]
        private EditContext CurrentEditContent { get; set; }
        protected override void OnInitialized()
        {
            if (CurrentEditContent == null)
            {
                throw new InvalidOperationException("コンポーネント作成エラー");
            }
            messageStore = new ValidationMessageStore(CurrentEditContent);
            CurrentEditContent.OnValidationRequested += (s, e) => messageStore.Clear();
            CurrentEditContent.OnFieldChanged += (s, e) => messageStore.Clear(e.FieldIdentifier);
        }

        public void DisplayErrors(Dictionary<string, List<string>> errors)
        {
            foreach (var err in errors)
            {
                messageStore.Add(CurrentEditContent.Field(err.Key), err.Value);
            }
            CurrentEditContent.NotifyValidationStateChanged();
        }
        public void ClearErrors()
        {
            messageStore.Clear();
            CurrentEditContent.NotifyValidationStateChanged();
        }
    }
}
